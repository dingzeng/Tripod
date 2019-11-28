/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Archive.Model
{
	[Table("branch_group_branch")]
	public partial class BranchGroupBranch : Entity
	{
		/// <summary>
		/// 自增编码
		/// <summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// 机构组id
		/// <summary>
		public int BranchGroupId { get; set; }

		/// <summary>
		/// 机构编码
		/// <summary>
		public string BranchId { get; set; }
	}
}
