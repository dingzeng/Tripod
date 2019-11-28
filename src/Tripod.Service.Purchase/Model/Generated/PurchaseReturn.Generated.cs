/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Purchase.Model
{
	[Table("purchase_return")]
	public partial class PurchaseReturn : Entity
	{
		/// <summary>
		/// 单据号
		/// <summary>
		[ExplicitKey]
		public string SheetId { get; set; }

		/// <summary>
		/// 引用采购收货单单据号
		/// <summary>
		public string RefSheetId { get; set; }

		/// <summary>
		/// 审核状态（0-草稿、1-为审核、2-审核通过、3-已驳回）
		/// <summary>
		public int ApproveStatus { get; set; }

		/// <summary>
		/// 供应商
		/// <summary>
		public string SupplierId { get; set; }

		/// <summary>
		/// 退货机构
		/// <summary>
		public string BranchId { get; set; }

		/// <summary>
		/// 出库仓库
		/// <summary>
		public string StoreId { get; set; }

		/// <summary>
		/// 订货金额
		/// <summary>
		public decimal TotalAmount { get; set; }

		/// <summary>
		/// 制单人
		/// <summary>
		public string CreateOper { get; set; }

		/// <summary>
		/// 制单时间
		/// <summary>
		public DateTime CreateTime { get; set; }

		/// <summary>
		/// 审核人
		/// <summary>
		public string ApproveOper { get; set; }

		/// <summary>
		/// 审核时间
		/// <summary>
		public DateTime ApproveTime { get; set; }

		/// <summary>
		/// 备注
		/// <summary>
		public string Memo { get; set; }
	}
}
