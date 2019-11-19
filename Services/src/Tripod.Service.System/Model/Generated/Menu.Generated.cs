/*
	本文件代码由代码生成工具自动生成，请不要手动修改
	生成时间：2019-11-19 21:17:28
*/
using System;
using Tripod.Framework.DapperExtentions.Attributes;
using Tripod.Framework.Common;

namespace Tripod.Service.System.Model
{
	[Table("menu")]
	public partial class Menu : Entity
	{
		/// <summary>
		/// 编码
		/// <summary>
		[ExplicitKey]
		public string Code { get; set; }

		/// <summary>
		/// 父级编码
		/// <summary>
		public string ParentCode { get; set; }

		/// <summary>
		/// 菜单路径
		/// <summary>
		public string Path { get; set; }

		/// <summary>
		/// 菜单名称
		/// <summary>
		public string Name { get; set; }

		/// <summary>
		/// 是否是叶子节点
		/// <summary>
		public int IsLeaf { get; set; }
	}
}
