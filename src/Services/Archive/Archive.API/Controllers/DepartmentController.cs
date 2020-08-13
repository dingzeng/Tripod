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
    [Route("/api/department")]
    public class DepartmentController : ControllerBase
    {
        private readonly ArchiveContext _archiveContext;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ArchiveContext context, ILogger<DepartmentController> logger)
        {
            _archiveContext = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(int pageIndex = 1, int pageSize = 20, string keyword = "")
        {
            var query = _archiveContext.Departments.AsQueryable();
            if(string.IsNullOrEmpty(keyword)) {
                query  = query.Where(i => i.Id.Contains(keyword) || i.Name.Contains(keyword));
            }

            var data = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderBy(i => i.Id);
            var response = new PaginatedItems<Department>(
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
            var department = _archiveContext.Departments.FirstOrDefault(i => i.Id == id);
            if(department == null) {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public IActionResult Post(Department model)
        {
            _archiveContext.Departments.Add(model);
            _archiveContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Department model)
        {
            _archiveContext.Update(model);
            _archiveContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]string id)
        {
            var department = _archiveContext.Departments.FirstOrDefault(i => i.Id == id);
            if(department == null) {
                return NotFound();
            }
            _archiveContext.Departments.Remove(department);
            _archiveContext.SaveChanges();

            return Ok();
        }
    }
}