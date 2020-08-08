using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tripod.Core;

namespace System.API.Model
{
	public partial class User : Entity
	{
		/// <summary>
		/// 自增编码
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// 所属机构编码
		/// </summary>
		public string BranchId { get; set; }

		/// <summary>
		/// 所属机构名称
		/// </summary>
		public string BranchName { get; set; }

		/// <summary>
		/// 用户名
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// 登录密码
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// 姓名
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 手机号
		/// </summary>
		public string Mobile { get; set; }

		/// <summary>
		/// 启用状态
		/// </summary>
		public bool Status { get; set; }

		/// <summary>
		/// 商品部门权限标记
		/// </summary>
		public PermissionFlag ItemDepartmentPermissionFlag { get; set; }

		/// <summary>
		/// 供应商权限标记
		/// </summary>
		public PermissionFlag SupplierPermissionFlag { get; set; }

		public IList<UserRole> UserRoles { get; set; }
	}
}
