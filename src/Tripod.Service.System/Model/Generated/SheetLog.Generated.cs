/*
	本文件代码由代码生成工具自动生成，请不要手动修改
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.System.Model
{
	[Table("sheet_log")]
	public partial class SheetLog : Entity
	{
		/// <summary>
		/// 子增长编码
		/// <summary>
		[Key]
		public long Id { get; set; }

		/// <summary>
		/// 单据类型
		/// <summary>
		public string SheetType { get; set; }

		/// <summary>
		/// 单据编号
		/// <summary>
		public string SheetId { get; set; }

		/// <summary>
		/// 操作 create、commit、approve、reject、cancel
		/// <summary>
		public string Action { get; set; }

		/// <summary>
		/// 操作人
		/// <summary>
		public string OperName { get; set; }

		/// <summary>
		/// 操作时间
		/// <summary>
		public DateTime CreateTime { get; set; }
	}
}
