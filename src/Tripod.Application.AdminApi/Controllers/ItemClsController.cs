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
    public class ItemClsController : ControllerBase
    {
        private readonly AppOptions _options;
        private readonly ILogger<ItemClsController> _logger;
        private readonly ItemSrv.ItemSrvClient _client;
        public ItemClsController(ILogger<ItemClsController> logger, IOptionsMonitor<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.ArchiveSrvHost, ChannelCredentials.Insecure);
            _client = new ItemSrv.ItemSrvClient(channel);
        }

        [HttpGet]
        public Response<PagedList<ItemClsDTO>> Get(int pageIndex = 1, int pageSize = 20, string keyword = "")
        {
            var request = new GetItemClssRequest();
            request.PageIndex = pageIndex;
            request.PageSize = pageSize;

            var response = _client.GetItemClss(request);
            return new PagedList<ItemClsDTO>()
            {
                List = response.ItemClss,
                TotalCount = response.TotalCount
            };
        }

        [HttpGet("{id}")]
        public Response<ItemClsDTO> Get(string id)
        {
            return _client.GetItemCls(new KeyObject()
            {
                Body = id
            });
        }

        [HttpPost]
        public Response<ItemClsDTO> Post(ItemClsDTO model) => _client.CreateItemCls(model);

        [HttpPut]
        public Response<bool> Put(ItemClsDTO model) => _client.UpdateItemCls(model).Body;

        [HttpDelete("{id}")]
        public Response<bool> Delete(string id) => _client.DeleteItemCls(new KeyObject() { Body = id }).Body;
    }
}