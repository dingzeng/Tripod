using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Tripod.Service.System
{
    public class UserService : Users.UsersBase
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override Task<User> GetUserByUsername(GetUserByUsernameRequest request, ServerCallContext context)
        {
            return Task.FromResult(new User
            {
                Username = request.Username
            });
        }
    }
}