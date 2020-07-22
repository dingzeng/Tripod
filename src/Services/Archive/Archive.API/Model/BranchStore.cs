using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archive.API.Model
{
	/// <summary>
	/// 机构仓库
	/// </summary>
    public class BranchStore
    {
		/// <summary>
		/// 自增编码
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// 所属机构编码
		/// </summary>
		public string BranchId { get; set; }

		/// <summary>
		/// 仓库名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 是否可用
		/// </summary>
		public int IsUsable { get; set; }
	}
}
