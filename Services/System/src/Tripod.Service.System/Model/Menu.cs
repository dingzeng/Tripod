using System;
using Dapper.Contrib.Extensions;

namespace Tripod.Service.System.Model
{
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