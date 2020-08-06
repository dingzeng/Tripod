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
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : UserGrpc.UserGrpcBase
    {
        private readonly ILogger<UserService> _logger;
        private readonly SystemContext _context;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public UserService(ILogger<UserService> logger, SystemContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// 检查用户名和密码，并返回存在的用户数据
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<UserDTO> CheckUsernameAndPassword(CheckUsernameAndPasswordRequest request, ServerCallContext context)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);

            if (user == null)
            {
                return new UserDTO();
            }
            else
            {
               return new UserDTO()
                {
                    UserId = user.Id.ToString(),
                    Username = user.Username
                };
            }
        }
    }
}
