using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;

namespace Tripod.Service.System
{
    public class UserService : Users.UsersBase
    {
        public override Task<User> GetUserByUsername(GetUserByUsernameRequest request, ServerCallContext context)
        {
            return Task.FromResult(new User{ Username = "admin" });
        }
    }
}