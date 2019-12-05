using System.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using Tripod.Service.System.Model;
using Tripod.Framework.Common.DAL;
using Tripod.Framework.Common;
using Dapper;

namespace Tripod.Service.System.DAL
{
    public class RoleDAO : BaseDAO<Role>
    {
        public RoleDAO(ConfigurationOptions options)
            : base(options.ConnectionString)
        {

        }

        public List<Role> GetRolesByUserId(long userId)
        {
            var sql = @"
SELECT
    a.*
FROM `role` a
INNER JOIN user_role b ON a.id = b.role_id
WHERE b.user_id = @userId";
            return Run(conn =>
            {
                return conn.Query<Role>(sql, new { userId }).ToList();
            });
        }

        public bool UpdateRolePermissions(int roleId, IList<string> permissionCodes)
        {
            if (permissionCodes == null || permissionCodes.Count == 0)
            {
                throw new ArgumentNullException(nameof(permissionCodes));
            }
            // TODO SQL注入漏洞处理
            var condition = string.Join(',', permissionCodes.Select(p => $"'{p}'"));
            return Run(conn =>
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("DELETE FROM role_permission WHERE role_id = @roleId;");
                builder.Append($"INSERT INTO role_permission(role_id, permission_code) SELECT @roleId,p.`code` FROM permission AS p WHERE p.`code` IN ({condition});");
                return conn.Execute(builder.ToString(), new { roleId = roleId }) > 0;
            });
        }
    }
}