/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.System.Model
{
	[Table("permission_api")]
	public partial class PermissionApi : Entity
	{
		/// <summary>
		/// 
		/// <summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// 所属权限
		/// <summary>
		public string PermissionCode { get; set; }

		/// <summary>
		/// URL
		/// <summary>
		public string Url { get; set; }

		/// <summary>
		/// HTTP请求方式：GET、POST、PUT、DELETE
		/// <summary>
		public string Method { get; set; }
	}
}
