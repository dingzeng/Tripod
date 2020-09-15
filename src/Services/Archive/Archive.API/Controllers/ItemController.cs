using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Archive.API.Infrastructure;
using Tripod.Core;
using Archive.API.Model;
using Microsoft.EntityFrameworkCore;
using Archive.API.ViewModel.Item;

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
            var query = _context.Items
                        .Include(i => i.Category3)
                        .Include(i => i.Brand)
                        .Include(i => i.Department)
                        .AsQueryable();

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
            var entity = _context.Items
                    .Include(i => i.Category1)
                    .Include(i => i.Category2)
                    .Include(i => i.Category3)
                    .Include(i => i.Brand)
                    .Include(i => i.Department)
                    .Include(i => i.Barcodes)
                    .Include(i => i.Packages)
                    .FirstOrDefault(i => i.Id == id);

            if(entity == null) {
                return NotFound();
            }

            var model = ItemModel.FromEntity(entity);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(ItemModel model)
        {
            var entity = ItemModel.ToEntity(model);

            // Category
            var category = _context.Categories.Include(c => c.Parent).First(c => c.Id == model.Category3.Id);
            if(category.Level != 3) {
                return BadRequest("only level 3");
            }
            entity.CategoryId1 = category.Parent.ParentId;
            entity.CategoryId2 = category.Parent.Id;
            entity.CategoryId3 = category.Id;

            // Brand
            var brand = _context.Brands.First(b => b.Id == model.Brand.Id);
            if(brand == null) {
                return BadRequest("指定的品牌不存在");
            }

            // Department
            var department = _context.Departments.First(d => d.Id == model.Department.Id);
            if(department == null) {
                return BadRequest("指定的部门不存在");
            }

            // TODO remote call and then validate
            // Supplier 

            _context.Items.Add(entity);
            _context.SaveChanges();

            return Ok(model);
        }

        [HttpPut]
        public IActionResult Put(ItemModel model)
        {
            var entity = ItemModel.ToEntity(model);

            // Category
            var category = _context.Categories.Include(c => c.Parent).First(c => c.Id == model.Category3.Id);
            if(category.Level != 3) {
                return BadRequest("only level 3");
            }
            entity.CategoryId1 = category.Parent.ParentId;
            entity.CategoryId2 = category.Parent.Id;
            entity.CategoryId3 = category.Id;

            // Brand
            var brand = _context.Brands.First(b => b.Id == model.Brand.Id);
            if(brand == null) {
                return BadRequest("指定的品牌不存在");
            }

            // Department
            var department = _context.Departments.First(d => d.Id == model.Department.Id);
            if(department == null) {
                return BadRequest("指定的部门不存在");
            }

            // TODO remote call and then validate
            // Supplier 

            _context.Items.Update(entity);
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

        [HttpGet]
        [Route("exists-id/{id}")]
        public IActionResult ExistsId(string id)
        {
            var exists = _context.Items.Count(i => i.Id == id) > 0;

            return Ok(exists);
        }

        [HttpGet]
        [Route("exists-barcode/{barcode}")]
        public IActionResult ExistsBarcode(string barcode)
        {
            var exists = _context.Items.Count(i => i.Barcode == barcode) > 0;

            exists |= _context.ItemBarcodes.Count(i => i.Barcode == barcode) > 0;

            return Ok(exists);
        }
    }
}
