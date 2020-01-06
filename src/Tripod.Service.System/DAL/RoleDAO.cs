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

        public bool ExistPermission(int roleId, string permissionCode)
        {
            if (string.IsNullOrEmpty(permissionCode))
            {
                throw new ArgumentNullException(nameof(permissionCode));
            }

            var sql = "SELECT 1 FROM role_permission WHERE role_id = @roleId AND permission_code = @permissionCode;";
            return Run(conn =>
            {
                return conn.Query(sql, new
                {
                    roleId,
                    permissionCode
                }).Count() > 0;
            });
        }

        public bool DeleteRolePermission(int roleId, string permissionCode)
        {
            if (string.IsNullOrEmpty(permissionCode))
            {
                throw new ArgumentNullException(nameof(permissionCode));
            }

            var sql = "DELETE FROM role_permission WHERE role_id = @roleId AND permission_code = @permissionCode;";
            return Run(conn =>
            {
                return conn.Execute(sql, new
                {
                    roleId,
                    permissionCode
                }) > 0;
            });
        }

        public bool AddRolePermission(int roleId, string permissionCode)
        {
            if (string.IsNullOrEmpty(permissionCode))
            {
                throw new ArgumentNullException(nameof(permissionCode));
            }

            var sql = "INSERT INTO role_permission(role_id, permission_code) VALUES(@roleId, @permissionCode);";
            return Run(conn =>
            {
                return conn.Execute(sql, new
                {
                    roleId,
                    permissionCode
                }) > 0;
            });
        }

        public List<RolePermissionFlag> GetRolePermissionsFlag(int roleId)
        {
            return Run(conn =>
            {
                var sql = @"
SELECT 
    permission.menu_code AS menuCode,
	permission.`code` AS permissionCode,
    permission.`name` as permissionName,
    CASE 
		WHEN ifnull(role_permission.id, 0) > 0 THEN 1
        ELSE 0
	END AS flag
FROM permission 
LEFT JOIN role_permission ON permission.code = role_permission.permission_code AND role_id = @roleId
";
                return conn.Query<RolePermissionFlag>(sql, new { roleId }).ToList();
            });
        }
    }

    public class RolePermissionFlag
    {
        public string MenuCode { get; set; }

        public string PermissionCode { get; set; }

        public string PermissionName { get; set; }

        public bool Flag { get; set; }
    }
}