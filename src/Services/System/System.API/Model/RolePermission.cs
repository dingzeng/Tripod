using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Tripod.Core;

namespace System.API.Model
{
    public class RolePermission : Entity
    {
        public long Id { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public string PermissionCode { get; set; }

        public Permission Permission { get; set; }
    }
}
