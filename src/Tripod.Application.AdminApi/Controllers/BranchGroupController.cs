using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tripod.Service.Archive;

namespace Tripod.Application.AdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BranchGroupController : ControllerBase
    {
        private readonly AppOptions _options;
        private readonly ILogger<BranchGroupController> _logger;
        private readonly BranchSrv.BranchSrvClient _client;

        public BranchGroupController(ILogger<BranchGroupController> logger, IOptionsMonitor<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.ArchiveSrvHost, ChannelCredentials.Insecure);
            _client = new BranchSrv.BranchSrvClient(channel);
        }

        [HttpGet("{id}")]
        public Response<BranchGroupDTO> Get(string id)
        {
            var request = new KeyObject()
            {
                Body = id
            };
            var response = _client.GetBranchGroup(request);
            return response;
        }

        [HttpGet]
        public Response<IEnumerable<BranchGroupDTO>> Get()
        {
            var response = _client.GetBranchGroups(new Empty());

            return response.BranchGroups;
        }

        [HttpPost]
        public Response<BranchGroupDTO> Post(BranchGroupDTO model)
        {
            return _client.CreateBranchGroup(model);
        }

        [HttpPut]
        public Response<bool> Put(BranchGroupDTO model)
        {
            return _client.UpdateBranchGroup(model).Body;
        }

        [HttpDelete("{id}")]
        public Response<bool> Delete(string id)
        {
            return _client.DeleteBranchGroup(new KeyObject() { Body = id }).Body;
        }
    }
}
