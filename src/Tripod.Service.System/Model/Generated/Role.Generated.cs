/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.System.Model
{
	[Table("role")]
	public partial class Role : Entity
	{
		/// <summary>
		/// 自增长编码
		/// <summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// 名称
		/// <summary>
		public string Name { get; set; }

		/// <summary>
		/// 备注
		/// <summary>
		public string Memo { get; set; }
	}
}
