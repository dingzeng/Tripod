using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;

namespace Tripod.Service.System
{
    public class UserService : Users.UsersBase
    {
        public override Task<User> GetUserByUsername(GetUserByUsernameRequest request)
        {
            return Task.FromResult(new User
            {
                Username = request.Username
            });
        }
    }
}