using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Tripod.Service.System.DAL;
using Tripod.Service.System.Model;
using Tripod.Framework.Common;
using AutoMapper;
using System.Diagnostics.CodeAnalysis;

namespace Tripod.Service.System.Services
{
    public class SystemService : SystemSrv.SystemSrvBase
    {
        private readonly MenuDAO _menuDao;
        private readonly PermissionDAO _permissionDao;
        private readonly PermissionApiDAO _permissionApiDao;
        private readonly UserDAO _userDao;
        private readonly RoleDAO _roleDao;
        private readonly IMapper _mapper;
        public SystemService(IMapper mapper, ConfigurationOptions options)
        {
            _menuDao = new MenuDAO(options);
            _permissionDao = new PermissionDAO(options);
            _permissionApiDao = new PermissionApiDAO(options);
            _userDao = new UserDAO(options);
            _roleDao = new RoleDAO(options);
            _mapper = mapper;
        }

        // Menu
        public override Task<MenusResponse> GetAllMenus(Empty request, ServerCallContext context)
        {
            var menus = _menuDao.GetAll();
            var res = new MenusResponse();
            res.Menus.AddRange(menus.Select(m => _mapper.Map<MenuDTO>(m)));
            return Task.FromResult(res);
        }

        // Permission
        public override Task<PermissionsResponse> GetAllPermissions(Empty request, ServerCallContext context)
        {
            var permissions = _permissionDao.GetAll();
            var res = new PermissionsResponse();
            res.Permissions.AddRange(permissions.Select(p => _mapper.Map<PermissionDTO>(p)));
            return Task.FromResult(res);
        }

        // PermissionApi
        public override Task<GetAllPermissionApisResponse> GetAllPermissionApis(Empty request, ServerCallContext context)
        {
            var permissionApis = _permissionApiDao.GetAll();
            var res = new GetAllPermissionApisResponse();
            res.PermissionApis.AddRange(permissionApis.Select(pa => _mapper.Map<PermissionApiDTO>(pa)));
            return Task.FromResult(res);
        }

        #region Role

        public override Task<RolesResponse> GetAllRoles(Empty request, ServerCallContext context)
        {
            var roles = _roleDao.GetAll();
            var res = new RolesResponse();
            res.Roles.AddRange(roles.Select(r => this._mapper.Map<RoleDTO>(r)));
            return Task.FromResult(res);
        }

        public override Task<RoleDTO> GetRoleById(KeyObject request, ServerCallContext context)
        {
            var role = _roleDao.Get(request.Body);
            return Task.FromResult(_mapper.Map<RoleDTO>(role));
        }

        public override Task<RoleDTO> CreateRole(RoleDTO request, ServerCallContext context)
        {
            long id = _roleDao.Insert(_mapper.Map<Role>(request));
            var role = _roleDao.Get(id);
            return Task.FromResult(_mapper.Map<RoleDTO>(role));
        }

        public override Task<BooleanObject> DeleteRoleById(KeyObject request, ServerCallContext context)
        {
            int roleId = Convert.ToInt32(request.Body);
            bool success = _roleDao.Delete(new Role { Id = roleId });
            return Task.FromResult(new BooleanObject { Body = success });
        }

        public override Task<BooleanObject> UpdateRole(RoleDTO request, ServerCallContext context)
        {
            bool success = _roleDao.Update(_mapper.Map<Role>(request));
            return Task.FromResult(new BooleanObject { Body = success });
        }

        public override Task<PermissionsResponse> GetRolePermissions(KeyObject request, ServerCallContext context)
        {
            var roleId = Convert.ToInt32(request.Body);
            var permissions = _permissionDao.GetPermissionsByRoleId(roleId);
            var res = new PermissionsResponse();
            res.Permissions.AddRange(permissions.Select(p => _mapper.Map<PermissionDTO>(p)));
            return Task.FromResult(res);
        }

        public override Task<BooleanObject> UpdateRolePermissions(UpdateRolePermissionsRequest request, ServerCallContext context)
        {
            bool success = _roleDao.UpdateRolePermissions(request.RoleId, request.PermissionCodes);
            return Task.FromResult(new BooleanObject { Body = success });
        }

        #endregion

        #region User

        public override Task<UserDTO> GetUserByUsername(GetUserByUsernameRequest request, ServerCallContext context)
        {
            var user = _userDao.GetUserByUsername(request.Username);
            return Task.FromResult(_mapper.Map<UserDTO>(user));
        }

        public override Task<GetUsersResponse> GetUsers(PagingRequest request, ServerCallContext context)
        {
            var pagingResult = _userDao.GetUserPaging(request.PageIndex, request.PageSize);
            var res = new GetUsersResponse();
            res.TotalCount = pagingResult.TotalCount;
            res.Users.AddRange(pagingResult.List.Select(u => _mapper.Map<UserDTO>(u)));

            return Task.FromResult(res);
        }

        public override Task<UserDTO> GetUserById(KeyObject request, ServerCallContext context)
        {
            var user = _userDao.Get(request.Body);
            return Task.FromResult(_mapper.Map<UserDTO>(user));
        }

        public override Task<UserDTO> CreateUser(UserUpdateRequest request, ServerCallContext context)
        {
            var id = _userDao.Insert(_mapper.Map<User>(request.User));
            _userDao.UpdateUserRoles((int)id, request.Roles.ToList());
            var user = _userDao.Get(id);
            return Task.FromResult(_mapper.Map<UserDTO>(user));
        }

        public override Task<BooleanObject> UpdateUSer(UserUpdateRequest request, ServerCallContext context)
        {
            bool success = _userDao.Update(_mapper.Map<User>(request.User));
            _userDao.UpdateUserRoles((int)request.User.Id, request.Roles.ToList());
            return Task.FromResult(new BooleanObject { Body = success });
        }

        public override Task<BooleanObject> DeleteUserById(KeyObject reqeust, ServerCallContext context)
        {
            int userId = Convert.ToInt32(reqeust.Body);
            bool success = _userDao.Delete(new User { Id = userId });
            return Task.FromResult(new BooleanObject { Body = success });
        }

        public override Task<RolesResponse> GetRolesByUserId(KeyObject request, ServerCallContext context)
        {
            var id = Convert.ToInt64(request.Body);
            var roles = _roleDao.GetRolesByUserId(id);
            var response = new RolesResponse();
            response.Roles.AddRange(roles.Select(r => _mapper.Map<RoleDTO>(r)));
            return Task.FromResult(response);
        }

        public override Task<MenuTree> GetUserMenus(KeyObject request, ServerCallContext context)
        {
            var id = Convert.ToInt64(request.Body);

            var allMenus = _menuDao.GetAll();

            var userPermissionMenus = new List<Menu>();
            var userPermissionLeafMenus = _userDao.GetUserMenus(id);
            foreach (var m in userPermissionLeafMenus)
            {
                userPermissionMenus.Add(m);
                var temp = new List<Menu>();
                FindParentMenus(allMenus, temp, m);
                userPermissionMenus.AddRange(temp);
            }
            userPermissionMenus = userPermissionMenus.Distinct(new MenuEqualityComparer()).ToList();

            var response = new MenuTree();
            var firstLevelMenus = userPermissionMenus.Where(s => string.IsNullOrEmpty(s.ParentCode)).Select(s => new MenuNode()
            {
                Code = s.Code,
                ParentCode = s.ParentCode,
                Path = s.Path,
                Name = s.Name,
                Icon = s.Icon,
                IsLeaf = s.IsLeaf
            }).ToList();
            response.Nodes.AddRange(firstLevelMenus);
            BuildMenuTree(userPermissionMenus, response.Nodes.ToList());

            return Task.FromResult(response);
        }

        private void FindParentMenus(List<Menu> all, List<Menu> findMenus, Menu current)
        {
            if (!string.IsNullOrEmpty(current.ParentCode))
            {
                var parent = all.Find(m => m.Code == current.ParentCode);
                findMenus.Add(parent);
                FindParentMenus(all, findMenus, parent);
            }
        }

        private void BuildMenuTree(List<Menu> source, List<MenuNode> nodes)
        {
            foreach (var node in nodes)
            {
                var children = source.Where(s => s.ParentCode == node.Code).Select(s => new MenuNode()
                {
                    Code = s.Code,
                    ParentCode = s.ParentCode,
                    Path = s.Path,
                    Name = s.Name,
                    Icon = s.Icon,
                    IsLeaf = s.IsLeaf
                }).ToList();
                node.Children.AddRange(children);
                BuildMenuTree(source, node.Children.ToList());
            }
        }

        public override Task<PermissionsResponse> GetUserPermissions(KeyObject request, ServerCallContext context)
        {
            var id = Convert.ToInt64(request.Body);
            var permissions = _userDao.GetUserPermissions(id);
            var response = new PermissionsResponse();
            response.Permissions.AddRange(permissions.Select(p => _mapper.Map<PermissionDTO>(p)));
            return Task.FromResult(response);
        }

        #endregion
    }

    public class MenuEqualityComparer : IEqualityComparer<Menu>
    {
        public bool Equals([AllowNull] Menu x, [AllowNull] Menu y)
        {
            return x.Code == y.Code;
        }

        public int GetHashCode([DisallowNull] Menu obj)
        {
            return obj.GetHashCode();
        }
    }
}