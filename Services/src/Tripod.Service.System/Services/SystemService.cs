using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Tripod.Service.System.DAL;
using Tripod.Service.System.Model;
using Tripod.Framework.Common;

namespace Tripod.Service.System
{
    public class SystemService : SystemSrv.SystemSrvBase
    {
        private readonly MenuDAO _menuDao;
        private readonly PermissionDAO _permissionDao;
        private readonly PermissionApiDAO _permissionApiDao;
        private readonly UserDAO _userDao;
        private readonly RoleDAO _roleDao;
        public SystemService(ConfigurationOptions options)
        {
            _menuDao = new MenuDAO(options);
            _permissionDao = new PermissionDAO(options);
            _permissionApiDao = new PermissionApiDAO(options);
            _userDao = new UserDAO(options);
            _roleDao = new RoleDAO(options);
        }

        // Menu
        public override Task<GetAllMenusResponse> GetAllMenus(Empty request, ServerCallContext context)
        {
            var menus = _menuDao.GetAll();
            var res = new GetAllMenusResponse();
            res.Menus.AddRange(menus.Select(m => m.ToDto()));
            return Task.FromResult(res);
        }

        // Permission
        public override Task<GetAllPermissionsResponse> GetAllPermissions(Empty request, ServerCallContext context)
        {
            var permissions = _permissionDao.GetAll();
            var res = new GetAllPermissionsResponse();
            res.Permissions.AddRange(permissions.Select(p => p.ToDto()));
            return Task.FromResult(res);
        }

        // PermissionApi
        public override Task<GetAllPermissionApisResponse> GetAllPermissionApis(Empty request, ServerCallContext context)
        {
            var permissionApis = _permissionApiDao.GetAll();
            var res = new GetAllPermissionApisResponse();
            res.PermissionApis.AddRange(permissionApis.Select(pa => pa.ToDto()));
            return Task.FromResult(res);
        }

        #region Role

        public override Task<GetAllRolesResponse> GetAllRoles(Empty request, ServerCallContext context)
        {
            var roles = _roleDao.GetAll();
            var res = new GetAllRolesResponse();
            res.Roles.AddRange(roles.Select(m => m.ToDto()));
            return Task.FromResult(res);
        }

        public override Task<RoleDTO> GetRoleById(KeyObject request, ServerCallContext context)
        {
            var role = _roleDao.Get(request.Body);
            return Task.FromResult(role.ToDto());
        }

        public override Task<RoleDTO> CreateRole(RoleDTO request, ServerCallContext context)
        {
            long id = _roleDao.Insert(request.ToEntity());
            var role = _roleDao.Get(id);
            return Task.FromResult(role.ToDto());
        }

        public override Task<BooleanObject> DeleteRoleById(KeyObject request, ServerCallContext context)
        {
            int roleId = Convert.ToInt32(request.Body);
            bool success = _roleDao.Delete(new Role { Id = roleId });
            return Task.FromResult(new BooleanObject { Body = success });
        }

        public override Task<BooleanObject> UpdateRole(RoleDTO request, ServerCallContext context)
        {
            bool success = _roleDao.Update(request.ToEntity());
            return Task.FromResult(new BooleanObject { Body = success });
        }

        public override Task<GetRolePermissionsResponse> GetRolePermissions(KeyObject request, ServerCallContext context)
        {
            var roleId = Convert.ToInt32(request.Body);
            var permissions = _permissionDao.GetPermissionsByRoleId(roleId);
            var res = new GetRolePermissionsResponse();
            res.Permissions.AddRange(permissions.Select(p => p.ToDto()));
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
            var result = new UserDTO()
            {
                Id = user.Id,
                BranchCode = user.BranchCode,
                Username = user.Username,
                Password = user.Password,
                Name = user.Name,
                Mobile = user.Mobile,
                Status = user.Status,
                ItemDepartmentPermissionFlag = user.ItemDepartmentPermissionFlag,
                SupplierPermissionFlag = user.SupplierPermissionFlag,
            };

            return Task.FromResult(result);
        }

        public override Task<GetUsersResponse> GetUsers(PagingRequest request, ServerCallContext context)
        {
            var pagingResult = _userDao.GetUserPaging(request.PageIndex, request.PageSize);
            var res = new GetUsersResponse();
            res.TotalCount = pagingResult.TotalCount;
            res.Users.AddRange(pagingResult.List.Select(u => u.ToDto()));

            return Task.FromResult(res);
        }

        public override Task<UserDTO> GetUserById(KeyObject request, ServerCallContext context)
        {
            var user = _userDao.Get(request.Body);
            return Task.FromResult(user.ToDto());
        }

        public override Task<UserDTO> CreateUser(UserDTO request, ServerCallContext context)
        {
            var id = _userDao.Insert(request.ToEntity());
            var user = _userDao.Get(id);
            return Task.FromResult(user.ToDto());
        }

        public override Task<BooleanObject> UpdateUSer(UserDTO reqeust, ServerCallContext context)
        {
            bool success = _userDao.Update(reqeust.ToEntity());
            return Task.FromResult(new BooleanObject { Body = success });
        }

        public override Task<BooleanObject> DeleteUserById(KeyObject reqeust, ServerCallContext context)
        {
            int userId = Convert.ToInt32(reqeust.Body);
            bool success = _userDao.Delete(new User { Id = userId});
            return Task.FromResult(new BooleanObject { Body = success });
        }

        #endregion
    }
}