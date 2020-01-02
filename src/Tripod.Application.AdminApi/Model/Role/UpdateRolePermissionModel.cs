using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tripod.Application.AdminApi.Model.Role
{
    public class UpdateRolePermissionModel
    {
        public int RoleId { get; set; }

        public string PermissionCode { get; set; }

        public bool Has { get; set; }
    }
}
