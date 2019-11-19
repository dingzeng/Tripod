using System;
using System.Text;
using Tripod.Service.System.Model;
using Tripod.Framework.Common.DAL;
using Dapper;
using Tripod.Framework.Common;

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
    }
}