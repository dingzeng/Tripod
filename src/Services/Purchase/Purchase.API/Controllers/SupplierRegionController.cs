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
    [Route("api/supplier-region")]
    public class SupplierRegionController : ControllerBase
    {
        private readonly PurchaseContext _context;

        private readonly ILogger<SupplierRegionController> _logger;

        public SupplierRegionController(ILogger<SupplierRegionController> logger, PurchaseContext contetxt)
        {
            this._logger = logger;
            this._context = contetxt;
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var entity = _context.SupplierRegions.FirstOrDefault(i => i.Id == id);
            if(entity == null) {
                return BadRequest();
            }

            return Ok(entity);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.SupplierRegions.ToList());
        }

        [HttpPost]
        public IActionResult Post(SupplierRegion model)
        {
            _context.SupplierRegions.Add(model);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(SupplierRegion model)
        {
            _context.SupplierRegions.Update(model);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _context.SupplierRegions.FirstOrDefault(i => i.Id == id);
            if(entity == null) {
                return BadRequest();
            }
            _context.SupplierRegions.Remove(entity);
            _context.SaveChanges();

            return Ok();
        }
    }
}
