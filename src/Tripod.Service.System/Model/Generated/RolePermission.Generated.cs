/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.System.Model
{
	[Table("role_permission")]
	public partial class RolePermission : Entity
	{
		/// <summary>
		/// 
		/// <summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public int RoleId { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public string PermissionCode { get; set; }
	}
}
