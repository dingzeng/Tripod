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
    /// <summary>
    /// 后台系统菜单
    /// </summary>
    [ApiController]
    [Route("system/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly AppOptions _options;
        private readonly ILogger<MenuController> _logger;
        private readonly SystemSrv.SystemSrvClient _client;

        public MenuController(ILogger<MenuController> logger, IOptionsMonitor<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.SystemSrvHost, ChannelCredentials.Insecure);
            _client = new SystemSrv.SystemSrvClient(channel);
        }

        [HttpGet]
        public Response<IEnumerable<MenuDTO>> Get(string parentCode)
        {
            return _client.GetMenus(new GetMenusRequest() { ParentCode = parentCode ?? "" }).Menus;
        }

        [HttpGet("tree")]
        public Response<List<TreeNode>> GetTree()
        {
            var response = new List<TreeNode>();
            var menus = _client.GetMenus(new GetMenusRequest()).Menus;
            var modules = menus.Where(m => string.IsNullOrEmpty(m.ParentCode));
            foreach (var module in modules)
            {
                var node = new TreeNode();
                node.Id = module.Code;
                node.Label = module.Name;
                node.Children = new List<TreeNode>();

                foreach (var group in menus.Where(m => m.ParentCode == module.Code))
                {
                    node.Children.Add(new TreeNode()
                    {
                        Id = group.Code,
                        Label = group.Name
                    });
                }

                response.Add(node);
            }

            return response;
        }
    }
}
