using System;
using System.Collections.Generic;

namespace Archive.API.Model
{
    /// <summary>
    /// 商品包装
    /// </summary>
    public class ItemPackage
    {
        /// <summary>
        /// 自增编码
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

		/// <summary>
		/// 商品编码
		/// </summary>
		public string ItemId { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        /// <value></value>
        public Item Item { get; set; }

		/// <summary>
		/// 条码
		/// </summary>
		public string Barcode { get; set; }

		/// <summary>
		/// 库存单位
		/// </summary>
		public string UnitName { get; set; }

		/// <summary>
		/// 包装系数
		/// </summary>
		public int FactorQty { get; set; }

        /// <summary>
        /// 采购价
        /// </summary>
        /// <value></value>
        public decimal? PurchasePrice { get; set; }

		/// <summary>
		/// 配送价
		/// </summary>
		/// <value></value>
		public decimal?	 DeliveryPrice { get; set; }

		/// <summary>
		/// 批发价
		/// </summary>
		public decimal? SalesPrice { get; set; }

		/// <summary>
		/// 零售价
		/// </summary>
		public decimal RetailPrice { get; set; }

		/// <summary>
		/// 是否为默认采购单位
		/// </summary>
		public bool IsDefaultPurchaseUnit { get; set; }

		/// <summary>
		/// 是否为默认配送单位
		/// </summary>
		public bool IsDefaultDeliveryUnit { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Memo { get; set; }
    }
}