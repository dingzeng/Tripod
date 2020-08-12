using Grpc.Core;
using GrpcSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.API.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.API.Grpc
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : UserGrpc.UserGrpcBase
    {
        private readonly ILogger<UserService> _logger;
        private readonly SystemContext _context;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public UserService(ILogger<UserService> logger, SystemContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// 检查用户名和密码，并返回存在的用户数据
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<UserDTO> CheckUsernameAndPassword(CheckUsernameAndPasswordRequest request, ServerCallContext context)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);

            if (user == null)
            {
                return new UserDTO();
            }
            else
            {
               return new UserDTO()
                {
                    UserId = user.Id.ToString(),
                    Username = user.Username
                };
            }
        }

        public override async Task<UserDTO> GetUserById(IdRequest request, ServerCallContext context)
        {
            var userId = Convert.ToInt32(request.Id);
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return new UserDTO();
            }
            else
            {
                return new UserDTO()
                {
                    UserId = user.Id.ToString(),
                    Username = user.Username
                };
            }
        }

        public override async Task<MenusAndPermissionDTO> GetUserMenusAndPermissions(IdRequest request, ServerCallContext context)
        {
            var response = new MenusAndPermissionDTO();
            var userId = Convert.ToInt32(request.Id);
            var permissions = await _context.Roles.Include(r => r.UserRoles).Include(r => r.RolePermissions)
                            .Where(r => r.UserRoles.Any(ur => ur.UserId == userId))
                            .SelectMany(r => r.RolePermissions.Select(rp => rp.Permission))
                            .Distinct()
                            .ToListAsync();
            
            var menuNodes = new List<MenuDTO>();
            var items = await _context.Menus.ToListAsync();
            foreach (var module in items.Where(i => string.IsNullOrEmpty(i.ParentCode)))
            {
                var moduleNode = new MenuDTO(){
                    Code = module.Code,
                    Path = module.Path,
                    Name = module.Name,
                    Icon = module.Icon,
                    IsLeaf = module.IsLeaf
                };
                foreach (var group in items.Where(i => i.ParentCode == module.Code))
                {
                    var groupNode = new MenuDTO() {
                        Code = group.Code,
                        Path = group.Path,
                        Name = group.Name,
                        Icon = group.Icon,
                        IsLeaf = group.IsLeaf
                    };
                    foreach (var menu in items.Where(i => i.ParentCode == group.Code))
                    {
                        var menuNode = new MenuDTO() {
                            Code = menu.Code,
                            Path = menu.Path,
                            Name = menu.Name,
                            Icon = menu.Icon,
                            IsLeaf = menu.IsLeaf
                        };
                        if(permissions.Exists(p => p.MenuCode == menu.Code)) {
                            groupNode.Children.Add(menuNode);
                        }
                    }
                    if(groupNode.Children.Count > 0) {
                        moduleNode.Children.Add(groupNode);
                    }
                }
                if(moduleNode.Children.Count > 0) {
                    menuNodes.Add(moduleNode);
                }
            }

            response.Permissions.AddRange(permissions.Select(p => new PermissionDTO(){
                Code = p.Code,
                MenuCode = p.MenuCode,
                Name = p.Name
            }));

            response.Menus.AddRange(menuNodes);

            return response;
        }
    }
}
