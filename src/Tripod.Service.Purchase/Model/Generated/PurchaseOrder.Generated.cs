/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Purchase.Model
{
	[Table("purchase_order")]
	public partial class PurchaseOrder : Entity
	{
		/// <summary>
		/// 单据号
		/// <summary>
		[ExplicitKey]
		public string SheetId { get; set; }

		/// <summary>
		/// 单据类型（0-采购订单、1-直配订单、2-越库订单、3-永续订单）
		/// <summary>
		public int Type { get; set; }

		/// <summary>
		/// 收货状态（0-未收货、1-部分收货、2-已收货）
		/// <summary>
		public int ReceiveStatus { get; set; }

		/// <summary>
		/// 审核状态（0-草稿、1-为审核、2-审核通过、3-已驳回）
		/// <summary>
		public int ApproveStatus { get; set; }

		/// <summary>
		/// 供应商
		/// <summary>
		public string SupplierId { get; set; }

		/// <summary>
		/// 订货机构
		/// <summary>
		public string OrderBranchId { get; set; }

		/// <summary>
		/// 收货期限
		/// <summary>
		public DateTime ReceiveExpireDate { get; set; }

		/// <summary>
		/// 订货金额
		/// <summary>
		public decimal TotalAmount { get; set; }

		/// <summary>
		/// 采购员
		/// <summary>
		public string PurchaseOper { get; set; }

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
