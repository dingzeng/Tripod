/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Purchase.Model
{
	[Table("purchase_order_branch")]
	public partial class PurchaseOrderBranch : Entity
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
		/// 机构
		/// <summary>
		public string BranchId { get; set; }
	}
}
