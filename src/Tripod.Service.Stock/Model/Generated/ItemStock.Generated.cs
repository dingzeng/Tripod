/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Stock.Model
{
	[Table("item_stock")]
	public partial class ItemStock : Entity
	{
		/// <summary>
		/// 自增编码
		/// <summary>
		[Key]
		public long Id { get; set; }

		/// <summary>
		/// 商品编码
		/// <summary>
		public string ItemId { get; set; }

		/// <summary>
		/// 商品条码
		/// <summary>
		public string Barcode { get; set; }

		/// <summary>
		/// 机构
		/// <summary>
		public string BranchId { get; set; }

		/// <summary>
		/// 仓库
		/// <summary>
		public string StoreId { get; set; }

		/// <summary>
		/// 库存数量
		/// <summary>
		public decimal Qty { get; set; }

		/// <summary>
		/// 成本价
		/// <summary>
		public decimal CostPrice { get; set; }

		/// <summary>
		/// 成本金额
		/// <summary>
		public decimal CostAmount { get; set; }
	}
}
