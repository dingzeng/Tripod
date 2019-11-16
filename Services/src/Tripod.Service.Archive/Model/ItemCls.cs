using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Archive.Model
{
	[Table("item_cls")]
	public class ItemCls : Entity
	{
		/// <summary>
		/// 编码
		/// <summary>
		[ExplicitKey]
		public string Id { get; set; }

		/// <summary>
		/// 上级类别编码
		/// <summary>
		public string ParentId { get; set; }

		/// <summary>
		/// 名称
		/// <summary>
		public string Name { get; set; }

	}
}
