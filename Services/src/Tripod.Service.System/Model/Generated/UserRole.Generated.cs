/*
	本文件代码由代码生成工具自动生成，请不要手动修改
	生成时间：2019-11-19 21:17:28
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.System.Model
{
	[Table("user_role")]
	public partial class UserRole : Entity
	{
		/// <summary>
		/// 
		/// <summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public int UserId { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public int RoleId { get; set; }
	}
}
