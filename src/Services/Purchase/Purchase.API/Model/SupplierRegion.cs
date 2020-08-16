using System;
using System.Collections.Generic;

namespace Purchase.API.Model
{
	/// <summary>
	/// 供应商区域
	/// </summary>
	public class SupplierRegion
	{
		/// <summary>
		/// 编码
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 供应商
		/// </summary>
		public IList<Supplier> Suppliers { get; set; }
	}
}