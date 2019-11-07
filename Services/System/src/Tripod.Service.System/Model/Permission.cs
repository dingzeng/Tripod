using System;

namespace Tripod.Service.System.Model
{
    public class Permission
    {
        public string Code { get; set; }

        public string MenuCode { get; set; }

        public PermissionType Type { get; set; }

        public string Name { get; set; }
    }
}