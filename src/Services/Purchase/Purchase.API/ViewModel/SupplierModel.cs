using System;
using Purchase.API.Model;

namespace Purchase.API.ViewModel
{
	/// <summary>
	/// 供应商
	/// </summary>
	public class SupplierModel
	{
		/// <summary>
		/// Ctor
		/// </summary>
		public SupplierModel()
		{
			
		}

		/// <summary>
		/// Ctor
		/// </summary>
		/// <param name="entity"></param>
		public SupplierModel(Supplier entity)
		{
			Id = entity.Id;
			Name = entity.Name;

			RegionId = entity.RegionId;
			if(entity.Region != null) {
				RegionName = entity.Region.Name;
			}

			Type = entity.Type;
			SettlementMode = entity.SettlementMode;
			SettleDays = entity.SettleDays;
			SettleDate = entity.SettleDate;
			Status = entity.Status;
			ContactsName = entity.ContactsName;
			ContactsMobile = entity.ContactsMobile;
			ContactsTel = entity.ContactsTel;
			ContactsEmail = entity.ContactsEmail;
			AccountBank = entity.AccountBank;
			AccountNo = entity.AccountNo;
			TaxRegistrationNo = entity.TaxRegistrationNo;
			BusinessLicenseNo = entity.BusinessLicenseNo;
			Memo = entity.Memo;
		}

		/// <summary>
		/// 供应商编码
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// 供应商名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 所属区域id
		/// </summary>
		public int RegionId { get; set; }

		/// <summary>
		/// 供应商区域
		/// </summary>
		public string RegionName { get; set; }

		/// <summary>
		/// 经营方式
		/// </summary>
		public SupplierType Type { get; set; }

		/// <summary>
		/// 结算方式
		/// </summary>
		public SettlementMode SettlementMode { get; set; }

		/// <summary>
		/// 结算周期天数
		/// </summary>
		public int? SettleDays { get; set; }

		/// <summary>
		/// 结算日期
		/// </summary>
		public string SettleDate { get; set; }

		/// <summary>
		/// 状态（0-正常、9-停用）
		/// </summary>
		public int Status { get; set; }

		/// <summary>
		/// 联系人
		/// </summary>
		public string ContactsName { get; set; }

		/// <summary>
		/// 移动电话
		/// </summary>
		public string ContactsMobile { get; set; }

		/// <summary>
		/// 固定电话
		/// </summary>
		public string ContactsTel { get; set; }

		/// <summary>
		/// Email
		/// </summary>
		public string ContactsEmail { get; set; }

		/// <summary>
		/// 开户行
		/// </summary>
		public string AccountBank { get; set; }

		/// <summary>
		/// 账号
		/// </summary>
		public string AccountNo { get; set; }

		/// <summary>
		/// 税务登记号
		/// </summary>
		public string TaxRegistrationNo { get; set; }

		/// <summary>
		/// 营业执照号
		/// </summary>
		public string BusinessLicenseNo { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Memo { get; set; }

		public Supplier ToEntity()
		{
			return new Supplier() 
			{
				Id = this.Id,
				Name = this.Name,
				RegionId = this.RegionId,
				Type = this.Type,
				SettlementMode = this.SettlementMode,
				SettleDays = this.SettleDays,
				SettleDate = this.SettleDate,
				Status = this.Status,
				ContactsName = this.ContactsName,
				ContactsMobile = this.ContactsMobile,
				ContactsTel = this.ContactsTel,
				ContactsEmail = this.ContactsEmail,
				AccountBank = this.AccountBank,
				AccountNo = this.AccountNo,
				TaxRegistrationNo = this.TaxRegistrationNo,
				BusinessLicenseNo = this.BusinessLicenseNo,
				Memo = this.Memo,
			};
		}
	}
}