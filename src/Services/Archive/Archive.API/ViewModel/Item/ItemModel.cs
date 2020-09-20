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
		[DisplayName("商品条码")]
		public string Barcode { get; set; }

		/// <summary>
		/// 商品名称
		/// </summary>
		[DisplayName("商品名称")]
		public string Name { get; set; }

		/// <summary>
		/// 简称
		/// </summary>
		[DisplayName("商品简称")]
		public string ShortName { get; set; }

		/// <summary>
		/// 三级类别
		/// </summary>
		[DisplayName("商品类别")]
		public string CategoryId3 { get; set; }

		public string CategoryName3 { get; set; }

		/// <summary>
		/// 品牌
		/// </summary>
		[DisplayName("商品品牌")]
		public string BrandId { get; set; }

		public string BrandName { get; set; }

		/// <summary>
		/// 部门
		/// </summary>
		[DisplayName("商品部门")]
		public string DepartmentId { get; set; }

		public string DepartmentName { get; set; }

		/// <summary>
		/// 主供应商
		/// </summary>
		[DisplayName("主供应商")]
		public string SupplierId { get; set; }

		public string SupplierName { get; set; }

		/// <summary>
		/// 库存单位名称
		/// </summary>
		[DisplayName("库存单位名称")]
		public string UnitName { get; set; }

		/// <summary>
		/// 状态 0-正常、9-停用
		/// </summary>
		[DisplayName("商品状态")]
		public int Status { get; set; }

		/// <summary>
		/// 零售价
		/// </summary>
		[DisplayName("零售价")]
		public decimal RetailPrice { get; set; }

		/// <summary>
		/// 进货价
		/// </summary>
		[DisplayName("进货价")]
		public decimal? PurchasePrice { get; set; }

		/// <summary>
		/// 批发价
		/// </summary>
		[DisplayName("批发价")]
		public decimal? SalesPrice { get; set; }

		/// <summary>
		/// 配送价
		/// </summary>
		[DisplayName("配送价")]
		public decimal? DeliveryPrice { get; set; }

		/// <summary>
		/// 参考毛利率
		/// </summary>
		[DisplayName("参考毛利率")]
		public decimal? ReferProfitRate { get; set; }

		/// <summary>
		/// 规格
		/// </summary>
		[DisplayName("规格")]
		public string Size { get; set; }

		/// <summary>
		/// 物流模式
		/// </summary>
		[DisplayName("物流模式")]
		public TransportMode TransportMode { get; set; }

		/// <summary>
		/// 保质天数
		/// </summary>
		[DisplayName("保质天数")]
		public int? QualityDays { get; set; }

		/// <summary>
		/// 临期预计天数
		/// </summary>
		[DisplayName("临期预计天数")]
		public int? WarningDays { get; set; }

		/// <summary>
		/// 最小配送数量
		/// </summary>
		[DisplayName("最小配送数量")]
		public int? LeastDeliveryQty { get; set; }

		/// <summary>
		/// 产地
		/// </summary>
		[DisplayName("产地")]
		public string ProductionPlace { get; set; }

		/// <summary>
		/// 进项税税率
		/// </summary>
		[DisplayName("进项税税率")]
		public decimal? PurchaseTaxRate { get; set; }

		/// <summary>
		/// 销项税税率
		/// </summary>
		[DisplayName("销项税税率")]
		public decimal? SalesTaxRate { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[DisplayName("备注")]
		public string Memo { get; set; }

        /// <summary>
        /// 商品条码
        /// </summary>
        /// <value></value>
		[DisplayName("商品条码")]
        public IList<ItemBarcode> Barcodes { get; set; }

        /// <summary>
        /// 商品包装
        /// </summary>
        /// <value></value>
		[DisplayName("商品包装")]
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