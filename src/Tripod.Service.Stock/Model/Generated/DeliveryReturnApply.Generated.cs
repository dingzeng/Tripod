/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Stock.Model
{
	[Table("delivery_return_apply")]
	public partial class DeliveryReturnApply : Entity
	{
		/// <summary>
		/// 单据号
		/// <summary>
		[ExplicitKey]
		public string SheetId { get; set; }

		/// <summary>
		/// 引用配送单号
		/// <summary>
		public string RefSheetId { get; set; }

		/// <summary>
		/// 入库机构
		/// <summary>
		public string BranchId { get; set; }

		/// <summary>
		/// 配送中心
		/// <summary>
		public string DeliveryBranchId { get; set; }

		/// <summary>
		/// 入库仓库
		/// <summary>
		public string StoreId { get; set; }

		/// <summary>
		/// 单据金额
		/// <summary>
		public decimal TotalAmount { get; set; }

		/// <summary>
		/// 审核状态（0-草稿、1-为审核、2-审核通过、3-已驳回）
		/// <summary>
		public int ApproveStatus { get; set; }

		/// <summary>
		/// 制单人
		/// <summary>
		public int CreateOperId { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public string CreateOperName { get; set; }

		/// <summary>
		/// 制单时间
		/// <summary>
		public DateTime CreateTime { get; set; }

		/// <summary>
		/// 审核人
		/// <summary>
		public int ApproveOperId { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public string ApproveOperName { get; set; }

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
