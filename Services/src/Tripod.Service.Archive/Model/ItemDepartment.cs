using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.Archive.Model
{
	[Table("item_department")]
	public class ItemDepartment : Entity
	{
		/// <summary>
		/// 自增编码
		/// <summary>
		[Key]
		public long? Id { get; set; }

		/// <summary>
		/// 名称
		/// <summary>
		public string Name { get; set; }

	}
}
