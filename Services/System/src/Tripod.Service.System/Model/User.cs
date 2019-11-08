using System;
using Dapper.Contrib.Extensions;

namespace Tripod.Service.System.Model
{
    public class User : Entity
    {
        [Key]
        public long Id { get; set; }

        public string BranchCode { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public bool Status { get; set; }

        public bool ItemDepartmentPermissionFlag { get; set; }

        public bool SupplierPermissionFlag { get; set; }
    }
}