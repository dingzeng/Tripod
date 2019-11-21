/*
	本文件代码由代码生成工具自动生成，请不要手动修改
	生成时间：2019-11-19 21:17:25
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Archive.Model
{
	[Table("branch_group")]
	public partial class BranchGroup : Entity
	{
		/// <summary>
		/// 自增编码
		/// <summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// 名称
		/// <summary>
		public string Name { get; set; }
	}
}
