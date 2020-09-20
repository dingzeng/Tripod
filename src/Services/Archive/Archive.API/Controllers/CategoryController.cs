using System;
using System.Collections.Generic;
using System.Linq;
using Archive.API.Infrastructure;
using Archive.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tripod.Core;
using AutoMapper;
using Archive.API.ViewModel;

namespace Archive.API.Controllers
{
    [ApiController]
    [Route("/api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ArchiveContext _archiveContext;
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;
        
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public CategoryController(ArchiveContext context, ILogger<CategoryController> logger,IMapper mapper)
        {
            _archiveContext = context;
            _logger = logger;
            _mapper = mapper;
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

            var model = _mapper.Map<CategoryModel>(entity);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CategoryModel model)
        {
            var entity = _mapper.Map<Category>(model);
            
            if(!string.IsNullOrEmpty(model.ParentId))
            {
                var parent = _archiveContext.Categories.First(c => c.Id == model.ParentId);
                entity.ParentId = model.ParentId;
                entity.Path = parent.Path + model.Id + ",";
                entity.Level = parent.Level + 1;
            }else {
                model.Path = "," + model.Id + ",";
                model.Level = 1;
            }

            _archiveContext.Categories.Add(entity);
            _archiveContext.SaveChanges();

            return Get(model.Id);
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
            _archiveContext.SaveChanges();

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
            root.Label = "全部类别";
            root.Children = new List<TreeNode>();
            BuildTree(root, list);

            return Ok(new List<TreeNode>() { root });
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