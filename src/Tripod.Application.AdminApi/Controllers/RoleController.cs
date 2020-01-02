using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tripod.Application.AdminApi.Model.Role;
using Tripod.Service.System;

namespace Tripod.Application.AdminApi.Controllers
{
    [ApiController]
    [Route("system/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly AppOptions _options;
        private readonly ILogger<RoleController> _logger;
        private readonly SystemSrv.SystemSrvClient _client;

        public RoleController(ILogger<RoleController> logger, IOptionsMonitor<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.SystemSrvHost, ChannelCredentials.Insecure);
            _client = new SystemSrv.SystemSrvClient(channel);
        }

        [HttpGet]
        public Response<IEnumerable<RoleDTO>> Get() => _client.GetAllRoles(new Empty()).Roles;

        [HttpGet("{id}")]
        public Response<RoleDTO> Get(string id) => _client.GetRoleById(new KeyObject() { Body = id });

        [HttpPost]
        public Response<RoleDTO> Post(RoleDTO model) => _client.CreateRole(model);

        [HttpPut]
        public Response<bool> Put(RoleDTO model) => _client.UpdateRole(model).Body;

        [HttpDelete("{id}")]
        public Response<bool> Delete(string id) => _client.DeleteRoleById(new KeyObject() { Body = id }).Body;

        [HttpGet("{roleId}/permissions")]
        public Response<IEnumerable<PermissionDTO>> GetRolePermissions(string roleId)
        {
            return _client.GetRolePermissions(new KeyObject() { Body = roleId }).Permissions;
        }

        [HttpPut("permission")]
        public Response<bool> UpdateRolePermission(UpdateRolePermissionModel model)
        {
            var request = new SetRolePermissionRequest();
            request.RoleId = model.RoleId;
            request.PermissionCode = model.PermissionCode;
            request.Has = model.Has;

            var response = _client.SetRolePermission(request);
            return response.Body;
        }
    }
}
