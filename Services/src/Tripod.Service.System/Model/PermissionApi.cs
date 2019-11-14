using System;
using Tripod.Framework.DapperExtentions.Attributes;

namespace Tripod.Service.System.Model
{
    [Table("permission_api")]
    public class PermissionApi : Entity
    {
        [Key]
        public int Id { get; set; }

        public string PermissionCode { get; set; }

        public string Url { get; set; }

        public string Method { get; set; }
    }
}