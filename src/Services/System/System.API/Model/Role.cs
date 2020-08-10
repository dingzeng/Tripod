using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tripod.Core;

namespace System.API.Model
{
	public partial class Role : Entity
	{
		/// <summary>
		/// 自增长编码
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Memo { get; set; }

        public IList<RolePermission> RolePermissions { get; set; }

        public IList<UserRole> UserRoles { get; set; }
    }
}
