/*
	本文件代码由代码生成工具自动生成，请不要手动修改
	生成时间：2019-11-19 21:17:25
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Archive.Model
{
	[Table("item_purchase_price")]
	public partial class ItemPurchasePrice : Entity
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
		/// 机构
		/// <summary>
		public string BranchId { get; set; }

		/// <summary>
		/// 供应商
		/// <summary>
		public string SupplierId { get; set; }

		/// <summary>
		/// 是否是主供应商
		/// <summary>
		public int IsPrimary { get; set; }

		/// <summary>
		/// 包装单位
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
		/// 进价
		/// <summary>
		public decimal PurchasePrice { get; set; }

		/// <summary>
		/// 备注
		/// <summary>
		public string Memo { get; set; }
	}
}
