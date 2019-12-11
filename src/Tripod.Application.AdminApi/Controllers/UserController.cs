using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tripod.Service.System;

namespace Tripod.Application.AdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly RpcOptions _rpcOptions;
        private readonly ILogger<UserController> _logger;
        private readonly SystemSrv.SystemSrvClient _client;

        public UserController(ILogger<UserController> logger, IOptionsMonitor<RpcOptions> rpcOptionsAccessor)
        {
            _rpcOptions = rpcOptionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_rpcOptions.SystemSrvHost, ChannelCredentials.Insecure);
            _client = new SystemSrv.SystemSrvClient(channel);
        }

        [HttpGet]
        public ActionResult<GetUsersResponse> Get(int pageIndex = 1, int pageSize = 20, string keyword = "")
        {
            return _client.GetUsers(new PagingRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword
            });
        }

        [HttpGet]
        public ActionResult<UserDTO> Get(string id)
        {
            return _client.GetUserById(new KeyObject() { Body = id });
        }

        [HttpPost]
        public ActionResult<UserDTO> Post(UserDTO model)
        {
            return _client.CreateUser(model);
        }

        [HttpPut]
        public ActionResult<bool> Put(UserDTO model)
        {
            return _client.UpdateUser(model).Body;
        }

        [HttpDelete]
        public ActionResult<bool> Delete(string id)
        {
            return _client.DeleteUserById(new KeyObject() { Body = id }).Body;
        }

        [HttpGet("permission")]
        public ActionResult<IEnumerable<PermissionDTO>> GetPermissions(string userId)
        {
            return _client.GetUserPermissions(new KeyObject() { Body = userId }).Permissions;
        }

        [HttpPut("permission")]
        public ActionResult<bool> PutPermissions(string userId, [FromBody]List<PermissionDTO> model)
        {
            throw new NotImplementedException();
        }
    }
}
