using System;
using Tripod.Service.System.Model;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

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
    }
}