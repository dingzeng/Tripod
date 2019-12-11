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
        private readonly RpcOptions _rpcOptions;
        private readonly ILogger<BranchController> _logger;
        private readonly BranchSrv.BranchSrvClient _client;

        public BranchController(ILogger<BranchController> logger, IOptionsMonitor<RpcOptions> rpcOptionsAccessor)
        {
            _rpcOptions = rpcOptionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_rpcOptions.ArchiveSrvHost, ChannelCredentials.Insecure);
            _client = new BranchSrv.BranchSrvClient(channel);
        }

        [HttpGet("{id}")]
        public ActionResult<BranchDTO> Get(string id)
        {
            var request = new KeyObject()
            {
                Body = id
            };
            var response = _client.GetBranch(request);
            return response;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BranchDTO>> Get(int pageIndex = 1, int pageSize = 20, string keyword = "", string parentId = "")
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
        public ActionResult<BranchDTO> Post(BranchDTO model)
        {
            return _client.CreateBranch(model);
        }

        [HttpPut]
        public ActionResult<bool> Put(BranchDTO model)
        {
            return _client.UpdateBranch(model).Body;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(string id)
        {
            return _client.DeleteBranch(new KeyObject() { Body = id }).Body;
        }
        
        [HttpGet("store")]
        public ActionResult<IEnumerable<StoreDTO>> GetStores(string branchId)
        {
            var request = new KeyObject()
            {
                Body = branchId
            };
            var response = _client.GetBranchStores(request);
            return response.Stores;
        }

        [HttpPut("store")]
        public ActionResult<bool> PutStores(string branchId, [FromBody]List<StoreDTO> model)
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
