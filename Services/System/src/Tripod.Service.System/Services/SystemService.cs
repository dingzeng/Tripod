using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Tripod.Service.System.DAL;

namespace Tripod.Service.System
{
    public class SystemService : SystemSrv.SystemSrvBase
    {
        private readonly UserDAO _userDao;
        private readonly RoleDAO _roleDao;
        public SystemService()
        {
            _userDao = new UserDAO();
            _roleDao = new RoleDAO();
        }

        public override Task<UserDTO> GetUserByUsername(GetUserByUsernameRequest request, ServerCallContext context)
        {
            var user = _userDao.GetUserByUsername(request.Username);
            var result = new UserDTO(){
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
    }
}