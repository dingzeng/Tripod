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
using Tripod.Application.AdminApi.Model.BranchGroup;
using Tripod.Service.Archive;

namespace Tripod.Application.AdminApi.Controllers
{
    /// <summary>
    /// 机构区域
    /// </summary>
    [ApiController]
    [Route("archive/[controller]")]
    public class BranchGroupController : ControllerBase
    {
        private readonly AppOptions _options;
        private readonly ILogger<BranchGroupController> _logger;
        private readonly BranchSrv.BranchSrvClient _client;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="optionsAccessor"></param>
        public BranchGroupController(ILogger<BranchGroupController> logger, IOptionsMonitor<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.ArchiveSrvHost, ChannelCredentials.Insecure);
            _client = new BranchSrv.BranchSrvClient(channel);
        }

        [HttpGet("{id}")]
        [PermissionFilter("BRANCH_GROUP_VIEW")]
        public Response<BranchGroupDTO> Get(string id) => _client.GetBranchGroup(new KeyObject() { Body = id });

        [HttpGet]
        [PermissionFilter("BRANCH_GROUP_VIEW")]
        public Response<PagedList<BranchGroupDTO>> Get(int pageIndex = 1, int pageSize = int.MaxValue, string keyword = "")
        {
            var request = new GetBranchGroupsRequest();
            request.PageIndex = pageIndex;
            request.PageSize = pageSize;
            request.Keyword = keyword ?? "";

            var response = _client.GetBranchGroups(request);
            return new PagedList<BranchGroupDTO>(response.BranchGroups, response.TotalCount);
        }

        [HttpPost]
        [PermissionFilter("BRANCH_GROUP_CREATE")]
        public Response<BranchGroupDTO> Post(BranchGroupDTO model) => _client.CreateBranchGroup(model);

        [HttpPut]
        [PermissionFilter("BRANCH_GROUP_UPDATE")]
        public Response<bool> Put(BranchGroupDTO model) => _client.UpdateBranchGroup(model).Body;

        [HttpDelete("{id}")]
        [PermissionFilter("BRANCH_GROUP_DELETE")]
        public Response<bool> Delete(string id) => _client.DeleteBranchGroup(new KeyObject() { Body = id }).Body;

        [HttpGet("branch/{branchGroupId}")]
        [PermissionFilter("BRANCH_GROUP_VIEW")]
        public Response<List<BranchDTO>> GetBranchs(string branchGroupId)
        {
            var response = _client.GetBranchGroupBranchs(new KeyObject() { Body = branchGroupId });
            return response.BranchGroupBranchs.ToList();
        }

        [HttpPut("branch")]
        [PermissionFilter("BRANCH_GROUP_UPDATE")]
        public Response<bool> UpdateBranchs(UpdateBranchsModel model)
        {
            var request = new UpdateBranchGroupBranchsRequest();
            request.BranchGroupId = model.BranchGroupId;
            request.BranchIdList.AddRange(model.BranchIdList);

            var response = _client.UpdateBranchGroupBranchs(request);
            return response.Body;
        }
    }
}
