/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Purchase.Model
{
	[Table("purchase_receive_detail")]
	public partial class PurchaseReceiveDetail : Entity
	{
		/// <summary>
		/// 
		/// <summary>
		[Key]
		public long Id { get; set; }

		/// <summary>
		/// 单据号
		/// <summary>
		public string SheetId { get; set; }

		/// <summary>
		/// 商品编码
		/// <summary>
		public string ItemId { get; set; }

		/// <summary>
		/// 商品条码
		/// <summary>
		public string ItemBarcode { get; set; }

		/// <summary>
		/// 商品名称
		/// <summary>
		public string ItemName { get; set; }

		/// <summary>
		/// 规格
		/// <summary>
		public string Size { get; set; }

		/// <summary>
		/// 采购单位
		/// <summary>
		public string PurchaseUnit { get; set; }

		/// <summary>
		/// 数量
		/// <summary>
		public decimal Qty { get; set; }

		/// <summary>
		/// 单价
		/// <summary>
		public decimal Price { get; set; }

		/// <summary>
		/// 金额
		/// <summary>
		public decimal Amount { get; set; }

		/// <summary>
		/// 税率
		/// <summary>
		public decimal TaxRate { get; set; }

		/// <summary>
		/// 税额
		/// <summary>
		public decimal TaxAmount { get; set; }

		/// <summary>
		/// 库存数量
		/// <summary>
		public decimal ReferStockQty { get; set; }

		/// <summary>
		/// 基本数量
		/// <summary>
		public decimal StockQty { get; set; }

		/// <summary>
		/// 库存单位
		/// <summary>
		public string StockUnit { get; set; }

		/// <summary>
		/// 生产日期
		/// <summary>
		public DateTime? ProduceDate { get; set; }

		/// <summary>
		/// 过期日期
		/// <summary>
		public DateTime? ExpireDate { get; set; }

		/// <summary>
		/// 备注
		/// <summary>
		public string Memo { get; set; }
	}
}
