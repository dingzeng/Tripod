using System;

namespace Archive.API.Model
{
    /// <summary>
    /// 商品采购价
    /// </summary>
    public class ItemPurchasePrice
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
		/// 机构
		/// </summary>
		public string BranchId { get; set; }

        /// <summary>
        /// 机构
        /// </summary>
        /// <value></value>
        public Branch Branch { get; set; }

		/// <summary>
		/// 供应商Id
		/// </summary>
		public string SupplierId { get; set; }

        /// <summary>
		/// 供应商名称
		/// </summary>
		public string SupplierName { get; set; }

		/// <summary>
		/// 是否是主供应商
		/// </summary>
		public bool IsPrimary { get; set; }

		/// <summary>
		/// 包装单位
		/// </summary>
		public string UnitName { get; set; }

		/// <summary>
		/// 包装系数
		/// </summary>
		public int FactorQty { get; set; }

		/// <summary>
		/// 进价
		/// </summary>
		public decimal PurchasePrice { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Memo { get; set; }
    }
}
