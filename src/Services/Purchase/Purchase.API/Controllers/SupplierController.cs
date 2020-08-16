using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purchase.API.Infrastructure;
using Purchase.API.Model;

namespace Purchase.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly PurchaseContext _context;

        private readonly ILogger<SupplierController> _logger;

        public SupplierController(ILogger<SupplierController> logger, PurchaseContext contetxt)
        {
            this._logger = logger;
            this._context = contetxt;
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            var entity = _context.Suppliers.FirstOrDefault(i => i.Id == id);
            if(entity == null) {
                return BadRequest();
            }

            return Ok(entity);
        }

        [HttpGet]
        public IActionResult Get(int pageIndex = 1, int pageSize = 20, string keyword = "")
        {
			var query = _context.Suppliers.AsQueryable();

			if(!string.IsNullOrEmpty(keyword)) {
				query = query.Where(i => i.Name.Contains(keyword) || i.Id.Contains(keyword));
			}

			var data = new Tripod.Core.PaginatedItems<Supplier>(
				pageIndex: pageIndex,
				pageSize: pageSize,
				count: query.Count(),
				data: query.ToList());

            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(Supplier model)
        {
            _context.Suppliers.Add(model);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Supplier model)
        {
            _context.Suppliers.Update(model);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            var entity = _context.Suppliers.FirstOrDefault(i => i.Id == id);
            if(entity == null) {
                return BadRequest();
            }
            _context.Suppliers.Remove(entity);
            _context.SaveChanges();

            return Ok();
        }

		[HttpGet]
		[Route("{id}/_exists")]
		public IActionResult Exists(string id)
		{
			var exists = _context.Suppliers.Any(s => s.Id == id);
			return Ok(exists);
		}
    }
}
