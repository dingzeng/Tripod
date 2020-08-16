using System;

namespace Purchase.API.Model
{
	/// <summary>
	/// 供应商类型
	/// </summary>
	public enum SupplierType
	{
		/// <summary>
		/// 购销
		/// </summary>
		PurchaseAndSale = 0,
		
		/// <summary>
		/// 购销
		/// </summary>
		Union = 1,

		/// <summary>
		/// 购销
		/// </summary>
		Proxy = 2,

		/// <summary>
		/// 购销
		/// </summary>
		Lease = 3
	}
}