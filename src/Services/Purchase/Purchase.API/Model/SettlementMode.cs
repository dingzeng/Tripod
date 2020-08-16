using System;

namespace Purchase.API.Model
{
	/// <summary>
	/// 结算方式
	/// </summary>
	public enum SettlementMode
	{
		/// <summary>
		/// 临时指定
		/// </summary>
		Temporary = 0,

		/// <summary>
		/// 货到付款
		/// </summary>
		OnDelivery = 1,

		/// <summary>
		/// 指定账期
		/// </summary>
		OnDays = 2,

		/// <summary>
		/// 指定日期
		/// </summary>
		OnDate = 3,
	}
}