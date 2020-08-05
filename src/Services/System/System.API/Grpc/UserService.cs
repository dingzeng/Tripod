using Grpc.Core;
using GrpcSystem;
using Microsoft.Extensions.Logging;
using System;
using System.API.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.API.Grpc
{
    public class UserService : UserGrpc.UserGrpcBase
    {
        private readonly ILogger<UserService> _logger;
        private readonly SystemContext _context;

        public UserService(ILogger<UserService> logger, SystemContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override Task<UserDTO> CheckUsernameAndPassword(CheckUsernameAndPasswordRequest request, ServerCallContext context)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);
            return Task.FromResult(new UserDTO()
            {
                UserId = user.Id.ToString(),
                Username = user.Name
            });
        }
    }
}
