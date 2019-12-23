using System;
using System.Collections.Generic;
using System.Linq;
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
    public class SupplierRegionController : ControllerBase
    {
        private readonly AppOptions _options;
        private readonly ILogger<SupplierRegionController> _logger;
        private readonly SupplierSrv.SupplierSrvClient _client;

        public SupplierRegionController(ILogger<SupplierRegionController> logger, IOptionsMonitor<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.ArchiveSrvHost, ChannelCredentials.Insecure);
            _client = new SupplierSrv.SupplierSrvClient(channel);
        }

        [HttpGet]
        public Response<IEnumerable<SupplierRegionDTO>> Get() => _client.GetSupplierRegions(new Empty()).SupplierRegions;

        [HttpGet("{id}")]
        public Response<SupplierRegionDTO> Get(string id) => _client.GetSupplierRegion(new KeyObject() { Body = id });

        [HttpGet("tree")]
        public Response<List<TreeNode>> GetTree()
        {
            var response = _client.GetSupplierRegions(new Empty());
            var children = response.SupplierRegions.Select(sr => new TreeNode() { Id = sr.Id.ToString(), Label = sr.Name });
            var root = new TreeNode()
            {
                Id = "",
                Label = "全部",
                Children = children.ToList()
            };
            return new List<TreeNode>() { root };
        }

        [HttpPost]
        public Response<SupplierRegionDTO> Post(SupplierRegionDTO model)
        {
            return _client.CreateSupplierRegion(model);
        }

        [HttpPut]
        public Response<bool> Put(SupplierRegionDTO model)
        {
            return _client.UpdateSupplierRegion(model).Body;
        }

        [HttpDelete("{id}")]
        public Response<bool> Delete(string id)
        {
            return _client.DeleteSupplierRegion(new KeyObject() { Body = id }).Body;
        }
    }
}