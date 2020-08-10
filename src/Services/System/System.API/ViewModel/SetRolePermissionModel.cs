using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.API.ViewModel
{
    public class SetRolePermissionModel
    {
        public int RoleId { get; set; }

        public string PermissionCode { get; set; }

        public bool Has { get; set; }
    }
}
