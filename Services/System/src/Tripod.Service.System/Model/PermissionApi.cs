using System;
using Dapper.Contrib.Extensions;

namespace Tripod.Service.System.Model
{
    public class PermissionApi : Entity
    {
        [Key]
        public int Id { get; set; }

        public string PermissionCode { get; set; }

        public string Url { get; set; }

        public string Method { get; set; }
    }
}