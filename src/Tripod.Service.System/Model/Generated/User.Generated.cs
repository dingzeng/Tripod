/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.System.Model
{
	[Table("user")]
	public partial class User : Entity
	{
		/// <summary>
		/// 自增编码
		/// <summary>
		[Key]
		public long Id { get; set; }

		/// <summary>
		/// 所属机构编码
		/// <summary>
		public string BranchCode { get; set; }

		/// <summary>
		/// 用户名
		/// <summary>
		public string Username { get; set; }

		/// <summary>
		/// 登录密码
		/// <summary>
		public string Password { get; set; }

		/// <summary>
		/// 姓名
		/// <summary>
		public string Name { get; set; }

		/// <summary>
		/// 手机号
		/// <summary>
		public string Mobile { get; set; }

		/// <summary>
		/// 状态 0-禁用、1-启用
		/// <summary>
		public int Status { get; set; }

		/// <summary>
		/// 商品部门权限标记 0-授权全部、1-指定授权
		/// <summary>
		public int ItemDepartmentPermissionFlag { get; set; }

		/// <summary>
		/// 供应商权限标记 0-授权全部、1-指定授权
		/// <summary>
		public int SupplierPermissionFlag { get; set; }
	}
}
