using System;
using System.Collections.Generic;
using System.Linq;
using Archive.API.Infrastructure;
using Archive.API.Model;
using Archive.API.ViewModel;
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
            if(string.IsNullOrEmpty(keyword)) {
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
                .Select(c => new CategoryModel(){
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentId,
                    ParentName = c.Parent == null ? "" : c.Parent.Name
                })
                .ToList();

            var response = new PaginatedItems<CategoryModel>(
                pageIndex: pageIndex,
                pageSize: pageSize,
                count: query.Count(),
                data: data);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute]string id)
        {
            var entity = _archiveContext.Categories.Include(c => c.Parent).FirstOrDefault(c => c.Id == id);
            if(entity == null) {
                return NotFound();
            }

            var model = new CategoryModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            if(entity.Parent != null) {
                model.ParentId = entity.ParentId;
                model.ParentName = entity.Parent.Name;
            }

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CategoryModel model)
        {
            Category entity = new Category();
            entity.Id = model.Id;
            entity.Name = model.Name;

            if(!string.IsNullOrEmpty(model.ParentId))
            {
                var parent = _archiveContext.Categories.First(c => c.Id == model.ParentId);
                entity.ParentId = model.ParentId;
                entity.Path = parent.Path + model.Id + ",";
                entity.Level = parent.Level + 1;
            }else {
                entity.Path = "," + model.Id + ",";
                entity.Level = 1;
            }

            _archiveContext.Categories.Add(entity);
            var lines = _archiveContext.SaveChanges();
            if(lines != 1) {
                return BadRequest();
            }

            return Ok(entity);
        }

        [HttpPut]
        public IActionResult Put(CategoryModel model)
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