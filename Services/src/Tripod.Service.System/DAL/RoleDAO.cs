using System.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using Tripod.Service.System.Model;
using Dapper;

namespace Tripod.Service.System.DAL
{
    public class RoleDAO : BaseDAO<Role>
    {
        public List<Role> GetRolesByUserId(long userId)
        {
            return Run(conn =>
            {
                return conn.Query<Role>("SELECT * FROM `role` WHERE EXISTS(SELECT 1 FROM user_role WHERE user_id = @userId);", new { userId = userId }).ToList();
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