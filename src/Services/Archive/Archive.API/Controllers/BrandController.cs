using System;
using System.Collections;
using System.Linq;
using Archive.API.Infrastructure;
using Archive.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tripod.Core;

namespace Archive.API.Controllers
{
    [ApiController]
    [Route("/api/brand")]
    public class BrandController: ControllerBase
    {
        private readonly ArchiveContext _archiveContext;
        private readonly ILogger<BrandController> _logger;

        public BrandController(ArchiveContext context, ILogger<BrandController> logger)
        {
            _archiveContext = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(int pageIndex = 1, int pageSize = 20, string keyword = "")
        {
            var query = _archiveContext.Brands.AsQueryable();
            if(string.IsNullOrEmpty(keyword)) {
                query  = query.Where(i => i.Id.Contains(keyword) || i.Name.Contains(keyword));
            }

            var data = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderBy(i => i.Id);
            var response = new PaginatedItems<Brand>(
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
            var brand = _archiveContext.Brands.FirstOrDefault(i => i.Id == id);
            if(brand == null) {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpPost]
        public IActionResult Post(Brand model)
        {
            _archiveContext.Brands.Add(model);
            _archiveContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Brand model)
        {
            _archiveContext.Update(model);
            _archiveContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]string id)
        {
            var brand = _archiveContext.Brands.FirstOrDefault(i => i.Id == id);
            if(brand == null) {
                return NotFound();
            }
            _archiveContext.Brands.Remove(brand);
            _archiveContext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("{id}/_exists")]
        public IActionResult Exists([FromRoute] string id)
        {
            var exists = _archiveContext.Brands.Any(b => b.Id == id);
            return Ok(exists);
        }
    }
}