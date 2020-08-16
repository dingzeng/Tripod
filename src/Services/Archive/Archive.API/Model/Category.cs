using System;
using System.Collections.Generic;
using Tripod.Core;

namespace Archive.API.Model
{
    /// <summary>
    /// 类别
    /// </summary>
    public class Category : Entity
    {
        /// <summary>
        /// 编码
        /// </summary>
        /// <value></value>
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// 父类别Id
        /// </summary>
        /// <value></value>
        public string ParentId { get; set; }

        /// <summary>
        /// 父类别
        /// </summary>
        /// <value></value>
        public Category Parent { get; set; }

        /// <summary>
        /// 节点层级
        /// </summary>
        /// <value></value>
        public int Level { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        /// <value></value>
        public string Path { get; set; }
    }
}