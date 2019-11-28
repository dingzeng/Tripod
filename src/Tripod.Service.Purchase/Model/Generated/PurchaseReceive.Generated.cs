/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Purchase.Model
{
	[Table("purchase_receive")]
	public partial class PurchaseReceive : Entity
	{
		/// <summary>
		/// 单据号
		/// <summary>
		[ExplicitKey]
		public string SheetId { get; set; }

		/// <summary>
		/// 引用采购订单单据号
		/// <summary>
		public string RefSheetId { get; set; }

		/// <summary>
		/// 审核状态（0-草稿、1-为审核、2-审核通过、3-已驳回）
		/// <summary>
		public int ApproveStatus { get; set; }

		/// <summary>
		/// 结算状态（0-未结算、1-已结算）
		/// <summary>
		public int SettleStatus { get; set; }

		/// <summary>
		/// 供应商
		/// <summary>
		public string SupplierId { get; set; }

		/// <summary>
		/// 收货机构
		/// <summary>
		public string ReceiveBranch { get; set; }

		/// <summary>
		/// 收货仓库
		/// <summary>
		public string ReceiveStoreId { get; set; }

		/// <summary>
		/// 订货金额
		/// <summary>
		public decimal TotalAmount { get; set; }

		/// <summary>
		/// 采购员
		/// <summary>
		public string PurchaseOper { get; set; }

		/// <summary>
		/// 收货时间
		/// <summary>
		public DateTime ReceiveTime { get; set; }

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
