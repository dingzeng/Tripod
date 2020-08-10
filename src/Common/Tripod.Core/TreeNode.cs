using System;
using System.Collections.Generic;
using System.Text;

namespace Tripod.Core
{
    public class TreeNode
    {
        public string Id { get; set; }

        public string Label { get; set; }

        public int Level { get; set; }

        public List<TreeNode> Children { get; set; }
    }
}
