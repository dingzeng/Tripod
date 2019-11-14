using System;
using Tripod.Framework.DapperExtentions.Attributes;

namespace Tripod.Service.System.Model
{
    [Table("permission")]
    public class Permission : Entity
    {
        [ExplicitKey]
        public string Code { get; set; }

        public string MenuCode { get; set; }

        public PermissionType Type { get; set; }

        public string Name { get; set; }
    }
}