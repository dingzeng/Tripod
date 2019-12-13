/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Stock.Model
{
	[Table("delivery_return_receive_detail_batch")]
	public partial class DeliveryReturnReceiveDetailBatch : Entity
	{
		/// <summary>
		/// 自增编码
		/// <summary>
		[Key]
		public long Id { get; set; }

		/// <summary>
		/// 单据号
		/// <summary>
		public string SheetId { get; set; }

		/// <summary>
		/// 单据明细id
		/// <summary>
		public long DetailId { get; set; }

		/// <summary>
		/// 批次号
		/// <summary>
		public string BatchId { get; set; }

		/// <summary>
		/// 剩余库存数量
		/// <summary>
		public decimal ReferBatchQty { get; set; }

		/// <summary>
		/// 数量
		/// <summary>
		public decimal Qty { get; set; }

		/// <summary>
		/// 过期日期
		/// <summary>
		public DateTime ExpireDate { get; set; }
	}
}
