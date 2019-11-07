using System.Linq;
using System;
using System.Collections.Generic;
using Tripod.Service.System.Model;
using Dapper;

namespace Tripod.Service.System.DAL
{
    public class RoleDAO : BaseDAO
    {
        public List<Role> GetRolesByUserId(long userId)
        {
            return Run(conn => {
              return conn.Query<Role>("SELECT * FROM `role` WHERE EXISTS(SELECT 1 FROM user_role WHERE user_id = @userId);",new {userId= userId}).ToList();
            });
        }
    }
}