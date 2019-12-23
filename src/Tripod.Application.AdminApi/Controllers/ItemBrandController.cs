using System;
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
    public class ItemBrandController : ControllerBase
    {
        private readonly AppOptions _options;
        private readonly ILogger<ItemBrandController> _logger;
        private readonly ItemSrv.ItemSrvClient _client;
        public ItemBrandController(ILogger<ItemBrandController> logger, IOptionsMonitor<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.ArchiveSrvHost, ChannelCredentials.Insecure);
            _client = new ItemSrv.ItemSrvClient(channel);
        }

        [HttpGet]
        public Response<PagedList<ItemBrandDTO>> Get(int pageIndex = 1, int pageSize = 20)
        {
            var request = new GetItemBrandsRequest();
            request.PageIndex = pageIndex;
            request.PageSize = pageSize;

            var response = _client.GetItemBrands(request);
            return new PagedList<ItemBrandDTO>()
            {
                TotalCount = response.TotalCount,
                List = response.ItemBrands
            };
        }

        [HttpGet("{id}")]
        public Response<ItemBrandDTO> Get(string id)
        {
            return _client.GetItemBrand(new KeyObject()
            {
                Body = id
            });
        }

        [HttpPost]
        public Response<ItemBrandDTO> Post(ItemBrandDTO model) => _client.CreateItemBrand(model);

        [HttpPut]
        public Response<bool> Put(ItemBrandDTO model) => _client.UpdateItemBrand(model).Body;

        [HttpDelete("{id}")]
        public Response<bool> Delete(string id) => _client.DeleteItemBrand(new KeyObject() { Body = id }).Body;
    }
}