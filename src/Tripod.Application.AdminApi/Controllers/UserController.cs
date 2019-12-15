using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tripod.Application.AdminApi.Model;
using Tripod.Service.System;

namespace Tripod.Application.AdminApi.Controllers
{
    [ApiController]
    [Route("system/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppOptions _options;
        private readonly ILogger<UserController> _logger;
        private readonly SystemSrv.SystemSrvClient _client;

        public UserController(ILogger<UserController> logger, IOptionsMonitor<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.SystemSrvHost, ChannelCredentials.Insecure);
            _client = new SystemSrv.SystemSrvClient(channel);
        }

        [HttpGet("_page")]
        public Response<dynamic> Page()
        {
            return new {
                
            };
        }

        [HttpGet]
        public Response<PagedList<UserDTO>> Get(int pageIndex = 1, int pageSize = 20, string keyword = "")
        {
            var response = _client.GetUsers(new PagingRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword
            });
            return new PagedList<UserDTO>(response.Users, response.TotalCount);
        }

        [HttpGet("{id}")]
        public Response<UserDTO> Get(string id) => _client.GetUserById(new KeyObject() { Body = id });

        [HttpPost]
        public Response<UserDTO> Post(UserDTO model) => _client.CreateUser(model);

        [HttpPut]
        public Response<bool> Put(UserDTO model) => _client.UpdateUser(model).Body;

        [HttpDelete]
        public Response<bool> Delete(string id) => _client.DeleteUserById(new KeyObject() { Body = id }).Body;

        [HttpGet("permission")]
        public Response<IEnumerable<PermissionDTO>> GetPermissions(string userId) => _client.GetUserPermissions(new KeyObject() { Body = userId }).Permissions;

        [HttpPut("permission")]
        public Response<bool> PutPermissions(string userId, [FromBody]List<PermissionDTO> model)
        {
            throw new NotImplementedException();
        }
    }
}
