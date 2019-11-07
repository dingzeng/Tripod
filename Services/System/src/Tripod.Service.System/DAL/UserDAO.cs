using System;
using Tripod.Service.System.Model;
using Dapper;

namespace Tripod.Service.System.DAL
{
    public class UserDAO : BaseDAO
    {
        public User GetUserByUsername(string username)
        {
            return Run(conn => {
                return conn.QuerySingle<User>("SELECT * FROM user WHERE username = @username", new { username = username });
            });
        }
    }
}