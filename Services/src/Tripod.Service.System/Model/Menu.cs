using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.System.Model
{
    [Table("menu")]
    public class Menu : Entity
    {
        [ExplicitKey]
        public string Code { get; set; }

        public string ParentCode { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public bool IsLeaf { get; set; }
    }
}