using System;
using System.Text;
using Tripod.Service.System.Model;
using Dapper;

namespace Tripod.Service.System.DAL
{
    public class UserDAO : BaseDAO<User>
    {
        public User GetUserByUsername(string username)
        {
            return Run(conn => {
                return conn.QueryFirstOrDefault<User>("SELECT * FROM user WHERE username = @username", new { username = username });
            });
        }

        public PagedList<User> GetUserPaging(int pageIndex = 1, int pageSize = int.MaxValue, bool? status = null)
        {
            string innerQuery = "SELECT * FROM `user`";

            StringBuilder builder = new StringBuilder();
            if(status.HasValue){
                builder.Append($"`status` = @status ");
            }
            string conditions = builder.ToString();

            var param = new {
                status = status.HasValue && status.Value ? '1' : '0'
            };

            return this.GetPaging<User>(innerQuery: innerQuery, pageIndex: pageIndex, pageSize: pageSize, conditions: conditions, param: param);
        }
    }
}