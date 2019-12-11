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
    public class MenuController : ControllerBase
    {
        private readonly RpcOptions _rpcOptions;
        private readonly ILogger<MenuController> _logger;
        private readonly SystemSrv.SystemSrvClient _client;

        public MenuController(ILogger<MenuController> logger, IOptionsMonitor<RpcOptions> rpcOptionsAccessor)
        {
            _rpcOptions = rpcOptionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_rpcOptions.SystemSrvHost, ChannelCredentials.Insecure);
            _client = new SystemSrv.SystemSrvClient(channel);
        }

        [HttpGet]
        public ActionResult<IEnumerable<MenuDTO>> Get()
        {
           return _client.GetAllMenus(new Empty()).Menus;
        }
    }
}
