using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archive.API.Model
{
    /// <summary>
    /// 机构类型
    /// </summary>
    public enum BranchType
    {
        /// <summary>
        /// 总部
        /// </summary>
        Headquarters = 0,

        /// <summary>
        /// 区域中心
        /// </summary>
        RegionalCentre = 1,

        /// <summary>
        /// 配送中心
        /// </summary>
        DC = 2,

        /// <summary>
        /// 自营店
        /// </summary>
        SelfShop = 3,

        /// <summary>
        /// 加盟店
        /// </summary>
        Franchisee = 4
    }
}
