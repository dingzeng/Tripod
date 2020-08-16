using System;
using System.Collections.Generic;
using System.Linq;
using Archive.API.Infrastructure;
using Archive.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tripod.Core;

namespace Archive.API.Controllers
{
    [ApiController]
    [Route("/api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ArchiveContext _archiveContext;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ArchiveContext context, ILogger<CategoryController> logger)
        {
            _archiveContext = context;
            _logger = logger;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyword"></param>
        /// <param name="ancestorId"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(
            int pageIndex = 1, 
            int pageSize = 20, 
            string keyword = "", 
            string ancestorId = "",
            int? level = null)
        {
            var query = _archiveContext.Categories.AsQueryable();
            if(!string.IsNullOrEmpty(keyword)) {
                query  = query.Where(i => i.Id.Contains(keyword) || i.Name.Contains(keyword));
            }

            if(!string.IsNullOrEmpty(ancestorId)) {
                query = query.Where(i => i.Path.Contains("," + ancestorId + ","));
            }

            if(level.HasValue) {
                query = query.Where(i => i.Level <= level);
            }

            var data = query.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(i => i.Id)
                .ToList();

            var page = new PaginatedItems<Category>(
                pageIndex: pageIndex,
                pageSize: pageSize,
                count: query.Count(),
                data: data);

            return Ok(page);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute]string id)
        {
            var entity = _archiveContext.Categories.Include(c => c.Parent).FirstOrDefault(c => c.Id == id);
            if(entity == null) {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Post(Category model)
        {
            if(!string.IsNullOrEmpty(model.ParentId))
            {
                var parent = _archiveContext.Categories.First(c => c.Id == model.ParentId);
                model.ParentId = model.ParentId;
                model.Path = parent.Path + model.Id + ",";
                model.Level = parent.Level + 1;
            }else {
                model.Path = "," + model.Id + ",";
                model.Level = 1;
            }

            model.Parent = null;
            _archiveContext.Categories.Add(model);
            var lines = _archiveContext.SaveChanges();
            if(lines != 1) {
                return BadRequest();
            }

            return RedirectToAction(nameof(Get), new { id = model.Id });
        }

        [HttpPut]
        public IActionResult Put(Category model)
        {
            var entity = _archiveContext.Categories.FirstOrDefault(c => c.Id == model.Id);
            if(entity == null) {
                return BadRequest();
            }
            
            // only change name
            entity.Name = model.Name;

            _archiveContext.Categories.Update(entity);
            var lines = _archiveContext.SaveChanges();
            if(lines != 1) {
                return BadRequest();
            }

            return Ok(entity);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]string id)
        {
            var category = _archiveContext.Categories.FirstOrDefault(i => i.Id == id);
            if(category == null) {
                return NotFound();
            }
            _archiveContext.Categories.Remove(category);
            _archiveContext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("tree")]
        public IActionResult Tree()
        {
            var list = _archiveContext.Categories.ToList();

            var root = new TreeNode();
            root.Id = null;
            root.Children = new List<TreeNode>();
            BuildTree(root, list);

            return Ok(root.Children);
        }

        private void BuildTree(TreeNode node, IEnumerable<Category> list)
        {
            var children = list.Where(c => c.ParentId == node.Id);
            foreach (var child in children)
            {
                var childNode = new TreeNode()
                {
                    Id = child.Id,
                    Label = $"[{child.Id}]{child.Name}",
                    Children = new List<TreeNode>()
                };
                node.Children.Add(childNode);
                BuildTree(childNode, list);
            }
        }
    }
}