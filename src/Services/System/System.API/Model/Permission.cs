using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tripod.Core;

namespace System.API.Model
{
	/// <summary>
	/// 权限
	/// </summary>
	public partial class Permission : Entity
	{
		/// <summary>
		/// 权限编码
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// 所属菜单
		/// </summary>
		public string MenuCode { get; set; }

		/// <summary>
		/// 权限名称
		/// </summary>
		public string Name { get; set; }
	}
}
