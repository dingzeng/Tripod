using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Archive.Model
{
	[Table("item_package")]
	public class ItemPackage : Entity
	{
		/// <summary>
		/// 
		/// <summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// 商品编码
		/// <summary>
		public string ItemId { get; set; }

		/// <summary>
		/// 条码
		/// <summary>
		public string Barcode { get; set; }

		/// <summary>
		/// 库存单位
		/// <summary>
		public int ItemUnitId { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public string ItemUnitName { get; set; }

		/// <summary>
		/// 包装系数
		/// <summary>
		public int FactorQty { get; set; }

		/// <summary>
		/// 零售价
		/// <summary>
		public decimal RetailPrice { get; set; }

		/// <summary>
		/// 批发价
		/// <summary>
		public decimal SalesPrice { get; set; }

		/// <summary>
		/// 是否为默认采购单位
		/// <summary>
		public int IsDefaultPurchaseUnit { get; set; }

		/// <summary>
		/// 是否为默认配送单位
		/// <summary>
		public int IsDefaultDeliveryUnit { get; set; }

		/// <summary>
		/// 备注
		/// <summary>
		public string Memo { get; set; }

	}
}
