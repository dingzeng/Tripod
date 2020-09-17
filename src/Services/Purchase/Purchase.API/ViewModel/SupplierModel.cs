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
		/// 供应商编码
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// 供应商名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 所属区域
		/// </summary>
		public SupplierRegion Region { get; set; }

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

		public static Supplier ToEntity(SupplierModel model)
		{
			return new Supplier() 
			{
				Id = model.Id,
				Name = model.Name,
				RegionId = model.Region.Id,
				Type = model.Type,
				SettlementMode = model.SettlementMode,
				SettleDays = model.SettleDays,
				SettleDate = model.SettleDate,
				Status = model.Status,
				ContactsName = model.ContactsName,
				ContactsMobile = model.ContactsMobile,
				ContactsTel = model.ContactsTel,
				ContactsEmail = model.ContactsEmail,
				AccountBank = model.AccountBank,
				AccountNo = model.AccountNo,
				TaxRegistrationNo = model.TaxRegistrationNo,
				BusinessLicenseNo = model.BusinessLicenseNo,
				Memo = model.Memo,
			};
		}

		public static SupplierModel FromEntity(Supplier entity)
		{
			var model = new SupplierModel();
			model.Region = new SupplierRegion();

			model.Id = entity.Id;
			model.Name = entity.Name;
			model.Region.Id = entity.RegionId;
			model.Type = entity.Type;
			model.SettlementMode = entity.SettlementMode;
			model.SettleDays = entity.SettleDays;
			model.SettleDate = entity.SettleDate;
			model.Status = entity.Status;
			model.ContactsName = entity.ContactsName;
			model.ContactsMobile = entity.ContactsMobile;
			model.ContactsTel = entity.ContactsTel;
			model.ContactsEmail = entity.ContactsEmail;
			model.AccountBank = entity.AccountBank;
			model.AccountNo = entity.AccountNo;
			model.TaxRegistrationNo = entity.TaxRegistrationNo;
			model.BusinessLicenseNo = entity.BusinessLicenseNo;
			model.Memo = entity.Memo;

			return model;
		}
	}
}