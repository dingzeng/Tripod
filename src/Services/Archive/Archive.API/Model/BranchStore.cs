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
		/// 所属机构
		/// </summary>
		/// <value></value>
		public Branch Branch { get; set; }

		/// <summary>
		/// 仓库名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 是否可用
		/// </summary>
		public bool IsUsable { get; set; }

        /// <summary>
        /// 是否为默认赠送仓库
        /// </summary>
        public bool IsDefaultGiftStoreId { get; set; }

        /// <summary>
        /// 是否为默认退货仓库
        /// </summary>
        public bool IsDefaultReturnStore { get; set; }

        /// <summary>
        /// 是否为默认进货仓库
        /// </summary>
        public bool IsDefaultPurchaseStore { get; set; }
	}
}
