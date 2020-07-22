using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archive.API.ViewModel
{
    public class TreeNode
    {
        public string Id { get; set; }

        public string Label { get; set; }

        public List<TreeNode> Children { get; set; }
    }
}
