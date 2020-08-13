using System;

namespace Archive.API.Model
{
    /// <summary>
    /// 物流模式
    /// </summary>
    public enum TransportMode
    {
        /// <summary>
        /// 统配
        /// </summary>
        /// <remark>
        /// 配送中心统一采购并配送到门店
        /// </remark>
        UnifiedDelivery = 0,

        /// <summary>
        /// 直配
        /// </summary>
        /// <remark>
        /// 配送中心进行采购后，供应商直接配送到门店
        /// </remark>
        DirectDelivery = 1,

        /// <summary>
        /// 自采
        /// </summary>
        /// <remark>
        /// 门店自行向供应商进行采购
        /// </remark>
        SelfPurchase = 2,

        /// <summary>
        /// 越库
        /// </summary>
        /// <remark>
        /// ？
        /// </remark>
        Cross = 3
    }
}