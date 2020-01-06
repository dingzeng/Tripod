using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tripod.Application.AdminApi.Attributes;
using Tripod.Application.AdminApi.Model;
using Tripod.Application.AdminApi.Model.User;
using Tripod.Service.System;

namespace Tripod.Application.AdminApi.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
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
            var response = _client.GetAllRoles(new Empty());
            return new
            {
                roles = response.Roles
            };
        }

        [HttpGet]
        [PermissionFilter("USER_VIEW")]
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
        [PermissionFilter("USER_VIEW")]
        public Response<UserDTO> Get(string id) => _client.GetUserById(new KeyObject() { Body = id });

        [HttpPost]
        [PermissionFilter("USER_CREATE")]
        public Response<UserDTO> Post(UserDTO model) => _client.CreateUser(model);

        [HttpPut]
        [PermissionFilter("USER_UPDATE")]
        public Response<bool> Put(UserDTO model) => _client.UpdateUser(model).Body;

        [HttpDelete]
        [PermissionFilter("USER_DELETE")]
        public Response<bool> Delete(string id) => _client.DeleteUserById(new KeyObject() { Body = id }).Body;

        #region User Role

        /// <summary>
        /// 获取用户关联的角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("role/{userId}")]
        [PermissionFilter("USER_VIEW")]
        public Response<IEnumerable<RoleDTO>> GetRoles(string userId)
        {
            var response = _client.GetRolesByUserId(new KeyObject() { Body = userId });
            return response.Roles;
        }

        /// <summary>
        /// 修改用户关联的角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("role")]
        [PermissionFilter("USER_UPDATE")]
        public Response<bool> UpdateRoles(UpdateRolesModel model)
        {
            var request = new UpdateUserRolesRequest();
            request.UserId = model.UserId;
            request.Roles.AddRange(model.RoleIdList);

            var response = _client.UpdateUserRoles(request);
            return response.Body;
        } 

        #endregion

        #region User Permission

        /// <summary>
        /// 获取用户拥有的操作权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("permission")]
        [PermissionFilter("USER_VIEW")]
        public Response<IEnumerable<PermissionDTO>> GetPermissions(string userId) => _client.GetUserPermissions(new KeyObject() { Body = userId }).Permissions;

        #endregion
    }
}
