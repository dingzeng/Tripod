using System;

namespace Tripod.Service.System.Model
{
    public class Menu
    {
        public string Code { get; set; }

        public string ParentCode { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public bool IsLeaf { get; set; }
    }
}