using System;
using System.Collections.Generic;
using System.Text;

namespace Tripod.Core
{
    public class RecordEntity : Entity
    {
		/// <summary>
		/// 创建人id
		/// </summary>
		public long CreateOperId { get; set; }

		/// <summary>
		/// 创建人
		/// </summary>
		public string CreateOperName { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime { get; set; }

		/// <summary>
		/// 最后修改人id
		/// </summary>
		public long LastUpdateOperId { get; set; }

		/// <summary>
		/// 最后修改人
		/// </summary>
		public string LastUpdateOperName { get; set; }

		/// <summary>
		/// 最后修改时间
		/// </summary>
		public DateTime LastUpdateTime { get; set; }
	}
}
