using System.Collections.Generic;
using Archive.API.Model;
using System.Diagnostics.Contracts;
using System.ComponentModel;

namespace Archive.API.ViewModel.Item
{
	public class ItemModel
	{
		/// <summary>
		/// 商品编码
		/// </summary>
		[DisplayName("商品编码")]
		public string Id { get; set; }

		/// <summary>
		/// 条码
		/// </summary>
		public string Barcode { get; set; }

		/// <summary>
		/// 商品名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 简称
		/// </summary>
		public string ShortName { get; set; }

		/// <summary>
		/// 三级类别
		/// </summary>
		public Category Category3 { get; set; }

		/// <summary>
		/// 品牌
		/// </summary>
		public Brand Brand { get; set; }

		/// <summary>
		/// 部门
		/// </summary>
		public Department Department { get; set; }

		/// <summary>
		/// 主供应商
		/// </summary>
		public SupplierModel Supplier { get; set; }

		/// <summary>
		/// 库存单位名称
		/// </summary>
		public string UnitName { get; set; }

		/// <summary>
		/// 状态 0-正常、9-停用
		/// </summary>
		public int Status { get; set; }

		/// <summary>
		/// 零售价
		/// </summary>
		public decimal RetailPrice { get; set; }

		/// <summary>
		/// 进货价
		/// </summary>
		public decimal? PurchasePrice { get; set; }

		/// <summary>
		/// 批发价
		/// </summary>
		public decimal? SalesPrice { get; set; }

		/// <summary>
		/// 配送价
		/// </summary>
		public decimal? DeliveryPrice { get; set; }

		/// <summary>
		/// 参考毛利率
		/// </summary>
		public decimal? ReferProfitRate { get; set; }

		/// <summary>
		/// 规格
		/// </summary>
		public string Size { get; set; }

		/// <summary>
		/// 物流模式
		/// </summary>
		public TransportMode TransportMode { get; set; }

		/// <summary>
		/// 保质天数
		/// </summary>
		public int? QualityDays { get; set; }

		/// <summary>
		/// 临期预计天数
		/// </summary>
		public int? WarningDays { get; set; }

		/// <summary>
		/// 最小配送数量
		/// </summary>
		public int? LeastDeliveryQty { get; set; }

		/// <summary>
		/// 产地
		/// </summary>
		public string ProductionPlace { get; set; }

		/// <summary>
		/// 进项税税率
		/// </summary>
		public decimal? PurchaseTaxRate { get; set; }

		/// <summary>
		/// 销项税税率
		/// </summary>
		public decimal? SalesTaxRate { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Memo { get; set; }

        /// <summary>
        /// 商品条码
        /// </summary>
        /// <value></value>
        public IList<ItemBarcode> Barcodes { get; set; }

        /// <summary>
        /// 商品包装
        /// </summary>
        /// <value></value>
        public IList<ItemPackage> Packages { get; set; }
	}

	public class SupplierModel
	{
		/// <summary>
		/// 主供应商Id
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// 主供应商名称
		/// </summary>
		public string Name { get; set; }
	}
}