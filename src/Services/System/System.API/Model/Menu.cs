using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tripod.Core;

namespace System.API.Model
{
	/// <summary>
	/// 菜单
	/// </summary>
	public partial class Menu : Entity
	{
		/// <summary>
		/// 编码
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// 父级编码
		/// </summary>
		public string ParentCode { get; set; }

		/// <summary>
		/// 菜单路径
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		/// 菜单名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 图标
		/// </summary>
		public string Icon { get; set; }

		/// <summary>
		/// 是否是叶子节点
		/// </summary>
		public bool IsLeaf { get; set; }

		/// <summary>
		/// 顺序
		/// </summary>
		public int Sequence { get; set; }
	}
}
