using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Archive.API.Infrastructure;
using Tripod.Core;
using Archive.API.Model;

namespace Archive.API.Controllers
{
    /// <summary>
    /// 商品
    /// </summary>
    [ApiController]
    [Route("/api/[controller]")]
    public class ItemController : ControllerBase
    {
        private ArchiveContext _context;
        private readonly ILogger<ItemController> _logger;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public ItemController(ArchiveContext context, ILogger<ItemController> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyword"></param>
        /// <param name="categoryId"></param>
        /// <param name="brandId"></param>
        /// <param name="departmentId"></param>
        /// <param name="status"></param>
        /// <param name="transportMode"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(
            int pageIndex = 1, 
            int pageSize = 20,
            string keyword = "",
            string categoryId = "",
            string brandId = "",
            string departmentId = "",
            int? status = null,
            TransportMode? transportMode = null)
        {
            var query = _context.Items.AsQueryable();

            if(!string.IsNullOrEmpty(keyword)) {
                query = query.Where(i => i.Name.Contains(keyword) || i.Barcode.Contains(keyword));
            }

            if(!string.IsNullOrEmpty(categoryId)) {
                var categoy = _context.Categories.First(c => c.Id == categoryId);
                if(categoy.Level == 1) {
                    query  = query.Where(i => i.CategoryId1 == categoryId);
                }else if(categoy.Level == 2) {
                    query  = query.Where(i => i.CategoryId2 == categoryId);
                }else if(categoy.Level == 3) {
                    query  = query.Where(i => i.CategoryId3 == categoryId);
                }
            }

            if(!string.IsNullOrEmpty(brandId)) {
                query = query.Where(i => i.BrandId == brandId);
            }

            if(!string.IsNullOrEmpty(departmentId)) {
                query = query.Where(i => i.DepartmentId == departmentId);
            }

            if(status.HasValue) {
                query = query.Where(i => i.Status == status.Value);
            }

            if(transportMode.HasValue) {
                query = query.Where(i => i.TransportMode == transportMode.Value);
            }

            var response = new PaginatedItems<Item>(
                pageIndex: pageIndex,
                pageSize: pageSize,
                count: query.Count(),
                data: query.OrderBy(i => i.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize)
            );

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            var entity = _context.Items.FirstOrDefault(i => i.Id == id);
            if(entity == null) {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Post(Item model)
        {
            _context.Items.Add(model);
            _context.SaveChanges();

            return Ok(model);
        }

        [HttpPut]
        public IActionResult Put(Item model)
        {
            _context.Items.Update(model);
            _context.SaveChanges();

            return Ok(model);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            var entity = _context.Items.FirstOrDefault(i => i.Id == id);
            if(entity == null) {
                return NotFound();
            }

            _context.Items.Remove(entity);
            _context.SaveChanges();

            return Ok();
        }
    }
}
