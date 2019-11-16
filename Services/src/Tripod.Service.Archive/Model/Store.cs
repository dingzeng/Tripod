using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Archive.Model
{
	[Table("store")]
	public class Store : Entity
	{
		/// <summary>
		/// 自增编码
		/// <summary>
		[Key]
		public long Id { get; set; }

		/// <summary>
		/// 所属机构编码
		/// <summary>
		public string BranchId { get; set; }

		/// <summary>
		/// 仓库名称
		/// <summary>
		public string Name { get; set; }

		/// <summary>
		/// 是否可用
		/// <summary>
		public int IsUsable { get; set; }
	}
}
