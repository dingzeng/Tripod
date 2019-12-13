using System;
using System.Collections.Generic;

namespace Tripod.Application.AdminApi.Model
{
    public class TreeNode
    {
        public string Id { get; set; }

        public string Label { get; set; }

        public List<TreeNode> Children { get; set; }
    }
}