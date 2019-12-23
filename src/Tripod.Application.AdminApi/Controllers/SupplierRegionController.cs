using System;
using System.Collections.Generic;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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