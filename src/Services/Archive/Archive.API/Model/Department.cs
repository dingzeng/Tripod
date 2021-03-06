using System;
using System.Collections.Generic;
using Tripod.Core;

namespace Archive.API.Model
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Department : Entity
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
        /// 商品
        /// </summary>
        /// <value></value>
        public IList<Item> Items { get; set; }
    }
}