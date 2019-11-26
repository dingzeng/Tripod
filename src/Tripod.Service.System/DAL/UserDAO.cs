using System;
using System.Text;
using Tripod.Service.System.Model;
using Tripod.Framework.Common.DAL;
using Dapper;
using Tripod.Framework.Common;
using System.Collections.Generic;
using System.Linq;

namespace Tripod.Service.System.DAL
{
    public class UserDAO : BaseDAO<User>
    {
        public UserDAO(ConfigurationOptions options)
            : base(options.ConnectionString)
        {

        }

        public User GetUserByUsername(string username)
        {
            return Run(conn =>
            {
                return conn.QueryFirstOrDefault<User>("SELECT * FROM user WHERE username = @username", new { username = username });
            });
        }

        public PagedList<User> GetUserPaging(int pageIndex = 1, int pageSize = int.MaxValue, bool? status = null)
        {
            StringBuilder builder = new StringBuilder();
            if (status.HasValue)
            {
                builder.Append($"`status` = @status ");
            }
            string conditions = builder.ToString();

            var param = new
            {
                status = status.HasValue && status.Value ? '1' : '0'
            };

            return this.GetPaging<User>(innerQuery: "`user`", pageIndex: pageIndex, pageSize: pageSize, conditions: conditions, param: param);
        }

        public List<Menu> GetUserMenus(long userId)
        {
            var sql = @"
SELECT
	a.`code`, 
    a.parent_code, 
    a.`path`, 
    a.`name`, 
    a.is_leaf
FROM menu a
INNER JOIN permission b on a.`code` = b.menu_code
INNER JOIN role_permission c on c.permission_code = b.code
INNER JOIN `role` d on d.id = c.role_id
INNER JOIN user_role e on e.role_id = d.id
INNER JOIN `user` f on f.id = e.user_id
WHERE b.`type` = 0 AND f.id = '@userId';";

            return Run(conn =>
            {
                return conn.Query<Menu>(sql, new { userId = userId }).ToList();
            });
        }

        public List<Permission> GetUserPermissions(long userId)
        {
            var sql = @"
SELECT
	a.`code`, 
    a.menu_code, 
    a.`type`, 
    a.`name`
FROM permission a
INNER JOIN role_permission b on b.permission_code = a.`code`
INNER JOIN `role` c on c.id = b.role_id
INNER JOIN user_role d on d.role_id = c.id
INNER JOIN `user` e on e.id = d.user_id
WHERE e.id = @userId;";

            return Run(conn =>
            {
                return conn.Query<Permission>(sql, new { userId = userId }).ToList();
            });
        }
    }
}