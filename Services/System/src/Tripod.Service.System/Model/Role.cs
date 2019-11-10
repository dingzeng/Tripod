using System;
using Dapper.Contrib.Extensions;

namespace Tripod.Service.System.Model
{
    [Table("role")]
    public class Role : Entity
    {
        [Key]
        public int Id { get;set; }
        public string Name { get;set; }
        public string Memo { get;set; }
    }
}