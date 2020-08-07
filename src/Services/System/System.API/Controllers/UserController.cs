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
    /// 用户
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly SystemContext _context;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public UserController(ILogger<UserController> logger, SystemContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="branchId"></param>
        /// <param name="keyword"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<User>> Get(
            int pageIndex = 1, 
            int pageSize = 20,
            string branchId = "",
            string keyword = "",
            int? status = null
            )
        {
            var query = _context.Users.AsQueryable();
            if(!string.IsNullOrEmpty(branchId)) {
                query = query.Where(i => i.BranchId == branchId);
            }
            if(!string.IsNullOrEmpty(keyword)) {
                query = query.Where(i => i.Username.Contains(keyword) || i.Name.Contains(keyword) || i.Mobile.Contains(keyword));
            }
            if(status.HasValue) {
                query = query.Where(i => i.Status == status.Value);
            }
            
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderByDescending(i => i.Id);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<User> Get(int id)
        {
            var user = _context.Users.FirstOrDefault(i => i.Id == id);
            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User model)
        {
            _context.Users.Add(model);
            var line = await _context.SaveChangesAsync();
            if(line < 1) {
                return BadRequest();
            }
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> Put(User model)
        {
            var user = _context.Users.FirstOrDefault(i => i.Id == model.Id);
            if(user == null) {
                return BadRequest();
            }

            user.BranchId = model.BranchId;
            user.BranchName = model.BranchName;
            user.Username = model.Username;
            user.Name = model.Name;
            user.Mobile = model.Mobile;
            user.ItemDepartmentPermissionFlag = model.ItemDepartmentPermissionFlag;
            user.SupplierPermissionFlag = model.SupplierPermissionFlag;

            var line = await _context.SaveChangesAsync();
            if(line < 1) {
                return BadRequest();
            }
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(i => i.Id == id);
            if(user == null) {
                return BadRequest();
            }

            _context.Remove(user);
            var line = await _context.SaveChangesAsync();
            if(line < 1) {
                return BadRequest();
            }
            return Ok();
        }
    }
}
