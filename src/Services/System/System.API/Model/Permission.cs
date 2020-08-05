using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tripod.Core;

namespace System.API.Model
{
	public partial class Permission : Entity
	{
		/// <summary>
		/// 
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// 所属菜单
		/// </summary>
		public string MenuCode { get; set; }

		/// <summary>
		/// 权限类型
		/// </summary>
		public PermissionType Type { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Name { get; set; }
	}
}
