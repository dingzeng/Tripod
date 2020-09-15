using System.Collections.Generic;
using Archive.API.Model;

namespace Archive.API.ViewModel.Item
{
	public class ItemModel
	{
		/// <summary>
		/// 商品编码
		/// </summary>
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
		/// 进项税
		/// </summary>
		public decimal? PurchaseTaxRate { get; set; }

		/// <summary>
		/// 销项税
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

		public static ItemModel FromEntity(Model.Item entity)
		{
			var model = new ItemModel();
			model.Supplier = new SupplierModel();

			model.Id = entity.Id;
			model.Category3 = entity.Category3;
            model.Brand = entity.Brand;
            model.Department = entity.Department;
            model.Supplier.Id = entity.SupplierId;
            model.Supplier.Name = entity.SupplierName;  

            model.Barcode = entity.Barcode;
            model.Name = entity.Name;
            model.ShortName = entity.ShortName;
            model.UnitName = entity.UnitName;
            model.Status = entity.Status;
            model.RetailPrice = entity.RetailPrice;
            model.PurchasePrice = entity.PurchasePrice;
            model.SalesPrice = entity.SalesPrice;
            model.DeliveryPrice = entity.DeliveryPrice;
            model.ReferProfitRate = entity.ReferProfitRate;
            model.Size = entity.Size;
            model.TransportMode = entity.TransportMode;
            model.QualityDays = entity.QualityDays;
            model.WarningDays = entity.WarningDays;
            model.LeastDeliveryQty = entity.LeastDeliveryQty;
            model.ProductionPlace = entity.ProductionPlace;
            model.PurchaseTaxRate = entity.PurchaseTaxRate;
            model.SalesTaxRate = entity.SalesTaxRate;
            model.Memo = entity.Memo;

            model.Barcodes = entity.Barcodes;
            model.Packages = entity.Packages;

			return model;
		}

		public static Model.Item ToEntity(ItemModel model)
		{
			var entity = new Model.Item();
			entity.Id = model.Id;
            entity.CategoryId3 = model.Category3.Id;
            entity.BrandId = model.Brand.Id;
            entity.DepartmentId = model.Department.Id;
            entity.SupplierId = model.Supplier.Id;
            entity.SupplierName = model.Supplier.Name;  

            entity.Barcode = model.Barcode;
            entity.Name = model.Name;
            entity.ShortName = model.ShortName;
            entity.UnitName = model.UnitName;
            entity.Status = model.Status;
            entity.RetailPrice = model.RetailPrice;
            entity.PurchasePrice = model.PurchasePrice;
            entity.SalesPrice = model.SalesPrice;
            entity.DeliveryPrice = model.DeliveryPrice;
            entity.ReferProfitRate = model.ReferProfitRate;
            entity.Size = model.Size;
            entity.TransportMode = model.TransportMode;
            entity.QualityDays = model.QualityDays;
            entity.WarningDays = model.WarningDays;
            entity.LeastDeliveryQty = model.LeastDeliveryQty;
            entity.ProductionPlace = model.ProductionPlace;
            entity.PurchaseTaxRate = model.PurchaseTaxRate;
            entity.SalesTaxRate = model.SalesTaxRate;
            entity.Memo = model.Memo;

            entity.Barcodes = model.Barcodes;
            entity.Packages = model.Packages;

			return entity;
		}
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