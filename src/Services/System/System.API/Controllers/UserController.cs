using System;
using System.API.Infrastructure;
using System.API.Model;
using System.API.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tripod.Core;

namespace System.API.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<PaginatedItems<User>> Get(
            int pageIndex = 1,
            int pageSize = 20,
            string branchId = "",
            string keyword = "",
            bool? status = null
            )
        {
            var query = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(branchId))
            {
                query = query.Where(i => i.BranchId == branchId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(i => i.Username.Contains(keyword) || i.Name.Contains(keyword) || i.Mobile.Contains(keyword));
            }
            if (status.HasValue)
            {
                query = query.Where(i => i.Status == status.Value);
            }

            var data = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderByDescending(i => i.Id);
            var response = new PaginatedItems<User>(
                pageIndex: pageIndex,
                pageSize: pageSize,
                count: query.Count(),
                data: data);

            return response;
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
            if (line < 1)
            {
                return BadRequest();
            }
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> Put(User model)
        {
            var user = _context.Users.FirstOrDefault(i => i.Id == model.Id);
            if (user == null)
            {
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
            if (line < 1)
            {
                return BadRequest();
            }
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(i => i.Id == id);
            if (user == null)
            {
                return BadRequest();
            }

            _context.Remove(user);
            var line = await _context.SaveChangesAsync();
            if (line < 1)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]
        [Route("role/{userId}")]
        public async Task<IActionResult> GetUserRoles(long userId)
        {
            var user = _context.Users.Include(u => u.UserRoles).FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return BadRequest();
            }

            var roles = user.UserRoles.Select(ur => ur.Role).ToList();
            return Ok(roles);
        }

        [HttpPut]
        [Route("role")]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleModel model)
        {
            var user = _context.Users.Include(u => u.UserRoles).FirstOrDefault(u => u.Id == model.UserId);
            if (user == null)
            {
                return BadRequest();
            }

            user.UserRoles.Clear();
            foreach (var roleId in model.RoleIdList)
            {
                user.UserRoles.Add(new UserRole()
                {
                    UserId = model.UserId,
                    RoleId = roleId
                });
            }
            var line = _context.SaveChanges();
            if (line < 1)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
