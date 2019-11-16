using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Archive.Model
{
	[Table("item_delivery_price")]
	public class ItemDeliveryPrice : Entity
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
		/// 机构
		/// <summary>
		public string BranchId { get; set; }

		/// <summary>
		/// 配送价
		/// <summary>
		public decimal DeliveryPrice { get; set; }

		/// <summary>
		/// 备注
		/// <summary>
		public string Memo { get; set; }
	}
}
