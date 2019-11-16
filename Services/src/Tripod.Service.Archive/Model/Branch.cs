using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Archive.Model
{
	[Table("branch")]
	public class Branch : Entity
	{
		/// <summary>
		/// 机构编码
		/// <summary>
		[ExplicitKey]
		public string Id { get; set; }

		/// <summary>
		/// 上级机构编码
		/// <summary>
		public string ParentId { get; set; }

		/// <summary>
		/// 机构名称
		/// <summary>
		public string Name { get; set; }

		/// <summary>
		/// 机构简称
		/// <summary>
		public string ShortName { get; set; }

		/// <summary>
		/// 机构类型（0-总部、1-区域中心、2-配送中心、3-自营店、4-加盟店）
		/// <summary>
		public int Type { get; set; }

		/// <summary>
		/// 联系人
		/// <summary>
		public string ContactsName { get; set; }

		/// <summary>
		/// 移动电话
		/// <summary>
		public string ContactsMobile { get; set; }

		/// <summary>
		/// 固定电话
		/// <summary>
		public string ContactsTel { get; set; }

		/// <summary>
		/// Email
		/// <summary>
		public string ContactsEmail { get; set; }

		/// <summary>
		/// 地址
		/// <summary>
		public string Address { get; set; }

		/// <summary>
		/// 默认赠送仓库
		/// <summary>
		public int GiftStoreId { get; set; }

		/// <summary>
		/// 默认退货仓库
		/// <summary>
		public int ReturnStoreId { get; set; }

		/// <summary>
		/// 默认进货仓库
		/// <summary>
		public int PurchaseStoreId { get; set; }

		/// <summary>
		/// 备注
		/// <summary>
		public string Memo { get; set; }

		/// <summary>
		/// 创建人
		/// <summary>
		public int CreateOperId { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public string CreateOperName { get; set; }

		/// <summary>
		/// 创建时间
		/// <summary>
		public DateTime CreateTime { get; set; }

		/// <summary>
		/// 最后修改人
		/// <summary>
		public int LastUpdateOperId { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public string LastUpdateOperName { get; set; }

		/// <summary>
		/// 最后修改时间
		/// <summary>
		public DateTime LastUpdateTime { get; set; }

	}
}
