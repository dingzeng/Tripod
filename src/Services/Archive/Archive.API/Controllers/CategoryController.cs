using System;
using System.Linq;
using Archive.API.Infrastructure;
using Archive.API.Model;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Get(int pageIndex = 1, int pageSize = 20, string keyword = "")
        {
            var query = _archiveContext.Categories.AsQueryable();
            if(string.IsNullOrEmpty(keyword)) {
                query  = query.Where(i => i.Id.Contains(keyword) || i.Name.Contains(keyword));
            }

            var data = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderBy(i => i.Id);
            var response = new PaginatedItems<Category>(
                pageIndex: pageIndex,
                pageSize: pageSize,
                count: query.Count(),
                data: data.ToList());
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute]string id)
        {
            var category = _archiveContext.Categories.FirstOrDefault(i => i.Id == id);
            if(category == null) {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Post(Category model)
        {
            _archiveContext.Categories.Add(model);
            _archiveContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Category model)
        {
            _archiveContext.Update(model);
            _archiveContext.SaveChanges();

            return Ok();
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
    }
}