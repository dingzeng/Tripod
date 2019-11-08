using System;
using Dapper.Contrib.Extensions;

namespace Tripod.Service.System.Model
{
    public class Permission : Entity
    {
        [ExplicitKey]
        public string Code { get; set; }

        public string MenuCode { get; set; }

        public PermissionType Type { get; set; }

        public string Name { get; set; }
    }
}