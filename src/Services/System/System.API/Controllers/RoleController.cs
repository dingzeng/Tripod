using System;
using System.API.Infrastructure;
using System.API.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace System.API.Controllers
{
    /// <summary>
    /// 角色
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly SystemContext _context;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public RoleController(ILogger<RoleController> logger, SystemContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Role>> Get(
            int pageIndex = 1, 
            int pageSize = 20,
            string keyword = ""
            )
        {
            var query = _context.Roles.AsQueryable();
            if(!string.IsNullOrEmpty(keyword)) {
                query = query.Where(i => i.Name.Contains(keyword));
            }
            
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderByDescending(i => i.Id);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<Role> Get(int id)
        {
            var role = _context.Roles.FirstOrDefault(i => i.Id == id);
            return role;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Role model)
        {
            _context.Roles.Add(model);
            var line = await _context.SaveChangesAsync();
            if(line < 1) {
                return BadRequest();
            }
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Role model)
        {
            var role = _context.Roles.FirstOrDefault(i => i.Id == model.Id);
            if(role == null) {
                return BadRequest();
            }

            role.Name = model.Name;
            role.Memo = model.Memo;

            var line = await _context.SaveChangesAsync();
            if(line < 1) {
                return BadRequest();
            }
            return Ok(role);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var role = _context.Roles.FirstOrDefault(i => i.Id == id);
            if(role == null) {
                return BadRequest();
            }

            _context.Remove(role);
            var line = await _context.SaveChangesAsync();
            if(line < 1) {
                return BadRequest();
            }
            return Ok();
        }
    }
}