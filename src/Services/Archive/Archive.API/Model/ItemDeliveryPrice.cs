using System;

namespace Archive.API.Model
{
    /// <summary>
    /// 商品配送价格
    /// </summary>
    public class ItemDeliveryPrice
    {
        /// <summary>
        /// 自增编码
        /// </summary>
        /// <value></value>
        public long Id { get; set; }

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
		/// 机构Id
		/// </summary>
		public string BranchId { get; set; }

        /// <summary>
        /// 机构
        /// </summary>
        /// <value></value>
        public Branch Branch { get; set; }

		/// <summary>
		/// 配送价
		/// </summary>
		public decimal DeliveryPrice { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Memo { get; set; }
    }
}