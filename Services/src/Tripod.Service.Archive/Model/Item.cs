using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Archive.Model
{
	[Table("item")]
	public class Item : Entity
	{
		/// <summary>
		/// 商品编码
		/// <summary>
		[ExplicitKey]
		public string Id { get; set; }

		/// <summary>
		/// 条码
		/// <summary>
		public string Barcode { get; set; }

		/// <summary>
		/// 商品名称
		/// <summary>
		public string Name { get; set; }

		/// <summary>
		/// 简称
		/// <summary>
		public string ShortName { get; set; }

		/// <summary>
		/// 商品类别
		/// <summary>
		public string ItemClsId { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public string ItemClsName { get; set; }

		/// <summary>
		/// 商品品牌
		/// <summary>
		public string ItemBrandId { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public string ItemBrandName { get; set; }

		/// <summary>
		/// 商品部门
		/// <summary>
		public string ItemDepartmentId { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public string ItemDepartmentName { get; set; }

		/// <summary>
		/// 库存单位
		/// <summary>
		public int ItemUnitId { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public string ItemUnitName { get; set; }

		/// <summary>
		/// 主供应商
		/// <summary>
		public string PrimarySupplierId { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public string PrimarySupplierName { get; set; }

		/// <summary>
		/// 状态 0-正常、9-停用
		/// <summary>
		public int Status { get; set; }

		/// <summary>
		/// 生鲜标志 0-非生鲜商品、1-生鲜商品
		/// <summary>
		public int IsFresh { get; set; }

		/// <summary>
		/// 零售价
		/// <summary>
		public decimal RetailPrice { get; set; }

		/// <summary>
		/// 进货价
		/// <summary>
		public decimal PurchasePrice { get; set; }

		/// <summary>
		/// 批发价
		/// <summary>
		public decimal SalesPrice { get; set; }

		/// <summary>
		/// 配送价
		/// <summary>
		public decimal DeliveryPrice { get; set; }

		/// <summary>
		/// 参考毛利率
		/// <summary>
		public decimal ReferProfitRate { get; set; }

		/// <summary>
		/// 规格
		/// <summary>
		public string Size { get; set; }

		/// <summary>
		/// 物流模式 0-统配、1-直配、2-自采、3-越库
		/// <summary>
		public int TransportMode { get; set; }

		/// <summary>
		/// 保质天数
		/// <summary>
		public int? QualityDays { get; set; }

		/// <summary>
		/// 临期预计天数
		/// <summary>
		public int? WarningDays { get; set; }

		/// <summary>
		/// 最小配送数量
		/// <summary>
		public int? LeastDeliveryQty { get; set; }

		/// <summary>
		/// 产地
		/// <summary>
		public string ProductionPlace { get; set; }

		/// <summary>
		/// 进项税
		/// <summary>
		public decimal? PurchaseTaxRate { get; set; }

		/// <summary>
		/// 销项税
		/// <summary>
		public decimal? SalesTaxRate { get; set; }

		/// <summary>
		/// 备注
		/// <summary>
		public string Memo { get; set; }

		/// <summary>
		/// 创建人
		/// <summary>
		public int CreateOperId { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public string CreateOperName { get; set; }

		/// <summary>
		/// 创建时间
		/// <summary>
		public DateTime CreateTime { get; set; }

		/// <summary>
		/// 最后修改人
		/// <summary>
		public int LastUpdateOperId { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public string LastUpdateOperName { get; set; }

		/// <summary>
		/// 最后修改时间
		/// <summary>
		public DateTime LastUpdateTime { get; set; }
	}
}
