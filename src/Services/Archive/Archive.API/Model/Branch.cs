using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tripod.Core;

namespace Archive.API.Model
{
    /// <summary>
    /// 机构档案
    /// </summary>
    public class Branch : RecordEntity
    {
        /// <summary>
        /// 机构编码
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 上级机构编码
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 上级机构
        /// </summary>
        public Branch Parent { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 机构简称
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 机构类型
        /// </summary>
        public BranchType Type { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactsName { get; set; }

        /// <summary>
        /// 移动电话
        /// </summary>
        public string ContactsMobile { get; set; }

        /// <summary>
        /// 固定电话
        /// </summary>
        public string ContactsTel { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string ContactsEmail { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 子机构
        /// </summary>
        /// <value></value>
        public IList<Branch> Children { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        /// <value></value>
        public IList<BranchStore> Stores { get; set; }
    }
}
