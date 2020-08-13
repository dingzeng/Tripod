using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tripod.Core
{
    public class RecordEntity : Entity
    {
		/// <summary>
		/// 创建人id
		/// </summary>
		[Required]
		public long CreateOperId { get; set; }

		/// <summary>
		/// 创建人
		/// </summary>
		[Required]
		public string CreateOperName { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime CreateTime { get; set; }

		/// <summary>
		/// 最后修改人id
		/// </summary>
		[Required]
		public long LastUpdateOperId { get; set; }

		/// <summary>
		/// 最后修改人
		/// </summary>
		[Required]
		public string LastUpdateOperName { get; set; }

		/// <summary>
		/// 最后修改时间
		/// </summary>
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime LastUpdateTime { get; set; }
	}
}
