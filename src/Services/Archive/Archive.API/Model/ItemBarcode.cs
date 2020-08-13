using System;

namespace Archive.API.Model
{
    /// <summary>
    /// 商品条码
    /// </summary>
    public class ItemBarcode
    {
        /// <summary>
		/// 自增编码
		/// </summary>
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
		/// 条码
		/// </summary>
		public string Barcode { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Memo { get; set; }
    }
}