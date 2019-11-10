using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Tripod.Service.System.Model;

namespace Tripod.Service.System.DAL
{
    public class PermissionDAO : BaseDAO<Permission>
    {
        public List<Permission> GetPermissionsByRoleId(int roleId)
        {
            return Run(conn => {
                var sql = "SELECT `code`, menu_code, `type`, `name` FROM `permission` WHERE EXISTS(SELECT 1 FROM `role_permission` WHERE role_id = @roleId)";
                return conn.Query<Permission>(sql, new { roleId = roleId }).ToList();
            });
        }
    }
}