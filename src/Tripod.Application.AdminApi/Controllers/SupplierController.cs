using System;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tripod.Application.AdminApi.Attributes;
using Tripod.Application.AdminApi.Model;
using Tripod.Service.Archive;

namespace Tripod.Application.AdminApi.Controllers
{
    /// <summary>
    /// π©”¶…Ã
    /// </summary>
    [ApiController]
    [Route("archive/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly AppOptions _options;
        private readonly ILogger<SupplierController> _logger;
        private readonly SupplierSrv.SupplierSrvClient _client;

        public SupplierController(ILogger<SupplierController> logger, IOptionsMonitor<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.ArchiveSrvHost, ChannelCredentials.Insecure);
            _client = new SupplierSrv.SupplierSrvClient(channel);
        }

        [HttpGet]
        [PermissionFilter("SUPPLIER_VIEW")]
        public Response<PagedList<SupplierDTO>> Get(int pageIndex = 1, int pageSize = 20, int regionId = 0, string keyword = "")
        {
            var request = new GetSuppliersRequest();
            request.PageIndex = pageIndex;
            request.PageSize = pageSize;
            request.SupplierRegionId = regionId;

            var response = _client.GetSuppliers(request);
            return new PagedList<SupplierDTO>()
            {
                List = response.Suppliers,
                TotalCount = response.TotalCount
            };
        }

        [HttpGet("{id}")]
        [PermissionFilter("SUPPLIER_VIEW")]
        public Response<SupplierDTO> Get(string id) => _client.GetSupplier(new KeyObject() { Body = id });

        [HttpPost]
        [PermissionFilter("SUPPLIER_CREATE")]
        public Response<SupplierDTO> Post(SupplierDTO model)
        {
            return _client.CreateSupplier(model);
        }

        [HttpPut]
        [PermissionFilter("SUPPLIER_UPDATE")]
        public Response<bool> Put(SupplierDTO model)
        {
           return _client.UpdateSupplier(model).Body;
        }

        [HttpDelete("{id}")]
        [PermissionFilter("SUPPLIER_DELETE")]
        public Response<bool> Delete(string id)
        {
            return _client.DeleteSupplier(new KeyObject(){Body=id}).Body;
        }
    }
}