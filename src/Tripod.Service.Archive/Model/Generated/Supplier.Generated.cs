/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Archive.Model
{
	[Table("supplier")]
	public partial class Supplier : Entity
	{
		/// <summary>
		/// 供应商编码
		/// <summary>
		[ExplicitKey]
		public string Id { get; set; }

		/// <summary>
		/// 供应商名称
		/// <summary>
		public string Name { get; set; }

		/// <summary>
		/// 所属区域id
		/// <summary>
		public string RegionId { get; set; }

		/// <summary>
		/// 经营方式（0-购销、1-联营、2-代销、3-租赁）
		/// <summary>
		public int SellWay { get; set; }

		/// <summary>
		/// 结算方式（0-临时指定、1-货到付款、2-指定账期、3-指定日期）
		/// <summary>
		public int SettleWay { get; set; }

		/// <summary>
		/// 结算周期天数
		/// <summary>
		public int? SettleDays { get; set; }

		/// <summary>
		/// 结算日期
		/// <summary>
		public string SettleDate { get; set; }

		/// <summary>
		/// 状态（0-正常、9-停用）
		/// <summary>
		public int Status { get; set; }

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
		/// 开户行
		/// <summary>
		public string AccountBank { get; set; }

		/// <summary>
		/// 账号
		/// <summary>
		public string AccountNo { get; set; }

		/// <summary>
		/// 税务登记号
		/// <summary>
		public string TaxRegistrationNo { get; set; }

		/// <summary>
		/// 营业执照号
		/// <summary>
		public string BusinessLicenseNo { get; set; }

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
