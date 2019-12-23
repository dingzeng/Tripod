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
    public class ItemUnitController: ControllerBase
    {
        private readonly AppOptions _options;
        private readonly ILogger<ItemUnitController> _logger;
        private readonly ItemSrv.ItemSrvClient _client;
        public ItemUnitController(ILogger<ItemUnitController> logger, IOptionsMonitor<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.ArchiveSrvHost, ChannelCredentials.Insecure);
            _client = new ItemSrv.ItemSrvClient(channel);
        }

        [HttpGet]
        public Response<PagedList<ItemUnitDTO>> Get(int pageIndex = 1, int pageSize = 20)
        {
            var request = new GetItemUnitsRequest();
            request.PageIndex = pageIndex;
            request.PageSize = pageSize;

            var response = _client.GetItemUnits(request);
            return new PagedList<ItemUnitDTO>()
            {
                TotalCount = response.TotalCount,
                List = response.ItemUnits
            };
        }

        [HttpGet("{id}")]
        public Response<ItemUnitDTO> Get(string id)
        {
            return _client.GetItemUnit(new KeyObject()
            {
                Body = id
            });
        }

        [HttpPost]
        public Response<ItemUnitDTO> Post(ItemUnitDTO model) => _client.CreateItemUnit(model);

        [HttpPut]
        public Response<bool> Put(ItemUnitDTO model) => _client.UpdateItemUnit(model).Body;

        [HttpDelete("{id}")]
        public Response<bool> Delete(string id) => _client.DeleteItemUnit(new KeyObject() { Body = id }).Body;
    }
}