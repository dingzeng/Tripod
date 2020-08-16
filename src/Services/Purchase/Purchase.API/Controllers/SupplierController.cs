using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Purchase.API.Infrastructure;
using Purchase.API.Model;
using Purchase.API.ViewModel;

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

            return Ok(new SupplierModel(entity));
        }

        [HttpGet]
        public IActionResult Get(int pageIndex = 1, int pageSize = 20, string keyword = "")
        {
			var query = _context.Suppliers.Include(s => s.Region).AsQueryable();

			if(!string.IsNullOrEmpty(keyword)) {
				query = query.Where(i => i.Name.Contains(keyword) || i.Id.Contains(keyword));
			}

            var data = query.Select(s => new SupplierModel(s));

			var page = new Tripod.Core.PaginatedItems<SupplierModel>(
				pageIndex: pageIndex,
				pageSize: pageSize,
				count: query.Count(),
				data: data);

            return Ok(page);
        }

        [HttpPost]
        public IActionResult Post(SupplierModel model)
        {
            var entity = model.ToEntity();

            _context.Suppliers.Add(entity);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(SupplierModel model)
        {
            var entity = model.ToEntity();

            _context.Suppliers.Update(entity);
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
