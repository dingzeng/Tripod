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
using Tripod.Application.AdminApi.Model;
using Microsoft.Extensions.Caching.Distributed;

namespace Tripod.Application.AdminApi.Controllers
{
    /// <summary>
    /// 账号
    /// </summary>
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly AppOptions _options;
        private readonly ILogger<IdentityController> _logger;
        private readonly SystemSrv.SystemSrvClient _client;
        private readonly IDistributedCache _chche;

        public IdentityController(ILogger<IdentityController> logger, IOptionsMonitor<AppOptions> optionsAccessor, IDistributedCache cache)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.SystemSrvHost, ChannelCredentials.Insecure);
            _client = new SystemSrv.SystemSrvClient(channel);

            _chche = cache;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public Response<string> Login(LoginModel model)
        {
            var user = _client.GetUserByUsername(new GetUserByUsernameRequest()
            {
                Username = model.Username
            });
            if (user == null || user.Password != model.Password)
            {
                throw new ApiException("用户名或密码错误");
            }

            var request = new KeyObject() { Body = user.Id.ToString() };
            var menus = _client.GetUserMenus(request);
            var permissions = _client.GetUserPermissions(request);
            var token = Guid.NewGuid().ToString().ToLower().Replace("-", "");

            var userInfo = new UserInfo()
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                Menus = menus.Nodes.ToList(),
                Permissions = permissions.Permissions.ToList()
            };
            string cache = JsonConvert.SerializeObject(userInfo);
            _chche.SetString(token, cache);
            return token;
        }

        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("userinfo")]
        public Response<UserInfo> GetUserInfo(string token)
        {
            var cache = _chche.GetString(token);
            return JsonConvert.DeserializeObject<UserInfo>(cache);
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("logout")]
        public Response<bool> Logout([FromBody]LogoutModel model)
        {
            _chche.Remove(model.Token);
            return true;
        }
    }
}
