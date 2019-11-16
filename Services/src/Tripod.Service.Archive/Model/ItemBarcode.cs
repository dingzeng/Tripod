using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Archive.Model
{
	[Table("item_barcode")]
	public class ItemBarcode : Entity
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
		/// 条码
		/// <summary>
		public string Barcode { get; set; }

		/// <summary>
		/// 备注
		/// <summary>
		public string Memo { get; set; }

	}
}
