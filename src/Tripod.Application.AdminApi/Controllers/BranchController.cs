﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tripod.Application.AdminApi.Model;
using Tripod.Service.Archive;

namespace Tripod.Application.AdminApi.Controllers
{
    [ApiController]
    [Route("archive/[controller]")]
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
        public Response<PagedList<BranchDTO>> Get(int pageIndex = 1, int pageSize = 20, string keyword = "", string parentId = "")
        {
            var response = _client.GetBranchs(new GetBranchsRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword,
                ParentId = parentId
            });

            return new PagedList<BranchDTO>(response.Branchs, response.TotalCount);
        }

        [HttpGet("tree")]
        public Response<List<TreeNode>> GetTree()
        {
            var response = _client.GetBranchs(new GetBranchsRequest()
            {
                PageIndex = 1,
                PageSize = int.MaxValue
            });
            var branchs = response.Branchs.Where(b => b.Type == 0 || b.Type == 1);

            var root = new TreeNode();
            root.Id = branchs.Where(b => b.Type == 0).First().Id;
            root.Label = branchs.Where(b => b.Type == 0).First().Name;
            root.Children = new List<TreeNode>();
            BuildTree(root, branchs);

            return new List<TreeNode>() { root };
        }

        private void BuildTree(TreeNode node, IEnumerable<BranchDTO> branchs)
        {
            var children = branchs.Where(b => b.ParentId == node.Id);
            foreach (var child in children)
            {
                var childNode = new TreeNode()
                {
                    Id = child.Id,
                    Label = child.Name,
                    Children = new List<TreeNode>()
                };
                node.Children.Add(childNode);
                BuildTree(childNode, branchs);
            }
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
