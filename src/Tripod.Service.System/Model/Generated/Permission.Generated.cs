/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.System.Model
{
	[Table("permission")]
	public partial class Permission : Entity
	{
		/// <summary>
		/// 
		/// <summary>
		[ExplicitKey]
		public string Code { get; set; }

		/// <summary>
		/// 所属菜单
		/// <summary>
		public string MenuCode { get; set; }

		/// <summary>
		/// 权限类型 0-查看、1-新增、2-修改、3-删除、4-审核、9-其它
		/// <summary>
		public int Type { get; set; }

		/// <summary>
		/// 
		/// <summary>
		public string Name { get; set; }
	}
}
