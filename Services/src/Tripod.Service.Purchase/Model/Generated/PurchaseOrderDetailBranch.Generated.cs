/*
	本文件代码由代码生成工具自动生成，请不要手动修改
	生成时间：2019-11-19 21:17:26
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Purchase.Model
{
	[Table("purchase_order_detail_branch")]
	public partial class PurchaseOrderDetailBranch : Entity
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
		/// 明细id
		/// <summary>
		public string DetailId { get; set; }

		/// <summary>
		/// 机构
		/// <summary>
		public string BranchId { get; set; }

		/// <summary>
		/// 库存数量
		/// <summary>
		public decimal ReferStockQty { get; set; }

		/// <summary>
		/// 数量
		/// <summary>
		public decimal Qty { get; set; }

		/// <summary>
		/// 备注
		/// <summary>
		public string Memo { get; set; }
	}
}
