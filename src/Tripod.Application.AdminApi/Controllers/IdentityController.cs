using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tripod.Application.AdminApi.Model.Identity;
using Tripod.Service.System;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace Tripod.Application.AdminApi.Controllers
{
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private const int REDIS_DATABASE = 0;
        private readonly AppOptions _options;
        private readonly ILogger<IdentityController> _logger;
        private readonly SystemSrv.SystemSrvClient _client;
        private readonly IDatabase _redis;

        public IdentityController(ILogger<IdentityController> logger, IOptionsMonitor<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.SystemSrvHost, ChannelCredentials.Insecure);
            _client = new SystemSrv.SystemSrvClient(channel);

            var connectionMultiplexer = ConnectionMultiplexer.Connect(_options.Redis);
            _redis = connectionMultiplexer.GetDatabase(REDIS_DATABASE);
        }

        [HttpPost]
        [Route("login")]
        public Response<bool> Login(LoginModel model)
        {
            var user = _client.GetUserByUsername(new GetUserByUsernameRequest()
            {
                Username = model.Username
            });
            if (user == null || user.Password != model.Password)
            {
                return false;
            }

            var request = new KeyObject() { Body = user.Id.ToString() };
            var menus = _client.GetUserMenus(request);
            var permissions = _client.GetUserPermissions(request);
            var token = Guid.NewGuid().ToString().ToLower().Replace("-", "");

            var userInfo = new UserInfo()
            {
                Name = user.Name,
                Menus = menus.Nodes.ToList(),
                Permissions = permissions.Permissions.ToList()
            };
            string cache = JsonConvert.SerializeObject(userInfo);
            return _redis.StringSet(token, cache);
        }

        [HttpGet]
        [Route("userinfo")]
        public Response<UserInfo> GetUserInfo([FromHeader]string token)
        {
            var cache = _redis.StringGet(token);
            return JsonConvert.DeserializeObject<UserInfo>(cache);
        }

        [HttpPost]
        [Route("logout")]
        public Response<bool> Logout([FromHeader]string token)
        {
            return _redis.KeyDelete(token);
        }
    }
}
