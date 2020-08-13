using System;

namespace Archive.API.Model
{
	/// <summary>
	/// 机构组机构关系
	/// </summary>
	public class BranchGroupBranch
	{
		/// <summary>
		/// 自增编码
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// 机构组Id
		/// </summary>
		public int BranchGroupId { get; set; }

		/// <summary>
		/// 机构组
		/// </summary>
		public BranchGroup BranchGroup { get; set; }

		/// <summary>
		/// 机构Id
		/// </summary>
		public string BranchId { get; set; }

		/// <summary>
		/// 机构
		/// </summary>
		public Branch Branch { get; set; }
	}
}