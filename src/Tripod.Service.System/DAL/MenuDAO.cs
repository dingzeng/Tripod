using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Tripod.Service.System.Model;
using Tripod.Framework.Common.DAL;
using Tripod.Framework.Common;

namespace Tripod.Service.System.DAL
{

    public class MenuDAO : BaseDAO<Menu>
    {
        public MenuDAO(ConfigurationOptions options)
            : base(options.ConnectionString)
        {

        }

        public List<Menu> GetMenus(string parentCode = "")
        {
            return Run(conn =>
            {
                string sql = "SELECT `code`, parent_code, `path`, `name`, icon, is_leaf FROM menu WHERE 1 = 1 ";
                if (!string.IsNullOrEmpty(parentCode))
                {
                    sql += "AND parent_code = @parentCode";
                }
                return conn.Query<Menu>(sql, new { parentCode }).ToList();
            });
        }
    }
}