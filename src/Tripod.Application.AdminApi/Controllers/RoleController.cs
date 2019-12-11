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
    public class RoleController : ControllerBase
    {
        private readonly RpcOptions _rpcOptions;
        private readonly ILogger<RoleController> _logger;
        private readonly SystemSrv.SystemSrvClient _client;

        public RoleController(ILogger<RoleController> logger, IOptionsMonitor<RpcOptions> rpcOptionsAccessor)
        {
            _rpcOptions = rpcOptionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_rpcOptions.SystemSrvHost, ChannelCredentials.Insecure);
            _client = new SystemSrv.SystemSrvClient(channel);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoleDTO>> Get()
        {
            return _client.GetAllRoles(new Empty()).Roles;
        }

        [HttpGet("{id}")]
        public ActionResult<RoleDTO> Get(string id)
        {
            return _client.GetRoleById(new KeyObject() { Body = id });
        }

        [HttpPost]
        public ActionResult<RoleDTO> Post(RoleDTO model)
        {
            return _client.CreateRole(model);
        }

        [HttpPut]
        public ActionResult<bool> Put(RoleDTO model)
        {
            return _client.UpdateRole(model).Body;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(string id)
        {
            return _client.DeleteRoleById(new KeyObject()
            {
                Body = id
            }).Body;
        }

        [HttpGet("permission")]
        public ActionResult<IEnumerable<PermissionDTO>> GetPermissions(string roleId)
        {
            return _client.GetRolePermissions(new KeyObject() { Body = roleId }).Permissions;
        }

        [HttpPut("permission")]
        public ActionResult<bool> UpdatePermissions(int roleId, [FromBody]List<string> model)
        {
            var request = new UpdateRolePermissionsRequest()
            {
                RoleId = roleId
            };
            request.PermissionCodes.AddRange(model);
            return _client.UpdateRolePermissions(request).Body;
        }
    }
}
