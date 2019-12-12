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
    public class BranchController : ControllerBase
    {
        private readonly AppOptions _options;
        private readonly ILogger<BranchController> _logger;
        private readonly BranchSrv.BranchSrvClient _client;

        public BranchController(ILogger<BranchController> logger, IOptionsMonitor<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.ArchiveSrvHost, ChannelCredentials.Insecure);
            _client = new BranchSrv.BranchSrvClient(channel);
        }

        [HttpGet("{id}")]
        public Response<BranchDTO> Get(string id) => _client.GetBranch(new KeyObject() { Body = id });

        [HttpGet]
        public Response<IEnumerable<BranchDTO>> Get(int pageIndex = 1, int pageSize = 20, string keyword = "", string parentId = "")
        {
            var response = _client.GetBranchs(new GetBranchsRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword,
                ParentId = parentId
            });

            return response.Branchs;
        }

        [HttpPost]
        public Response<BranchDTO> Post(BranchDTO model) => _client.CreateBranch(model);

        [HttpPut]
        public Response<bool> Put(BranchDTO model) => _client.UpdateBranch(model).Body;

        [HttpDelete("{id}")]
        public Response<bool> Delete(string id) => _client.DeleteBranch(new KeyObject() { Body = id }).Body;

        [HttpGet("store")]
        public Response<IEnumerable<StoreDTO>> GetStores(string branchId) => _client.GetBranchStores(new KeyObject() { Body = branchId }).Stores;

        [HttpPut("store")]
        public Response<bool> PutStores(string branchId, [FromBody]List<StoreDTO> model)
        {
            var request = new UpdateBranchStoresRequest()
            {
                BranchId = branchId
            };
            request.Stores.AddRange(model);
            var response = _client.UpdateBranchStores(request);
            return response.Body;
        }
    }
}
