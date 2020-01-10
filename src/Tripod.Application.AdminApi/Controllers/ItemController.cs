using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tripod.Application.AdminApi.Model;
using Tripod.Service.Archive;

namespace Tripod.Application.AdminApi.Controllers
{
    /// <summary>
    /// 商品
    /// </summary>
    [ApiController]
    [Route("archive/[controller]")]
    public class ItemController : AdminControllerBase
    {
        private readonly AppOptions _options;
        private readonly ILogger<ItemController> _logger;
        private readonly ItemSrv.ItemSrvClient _client;

        public ItemController(ILogger<ItemController> logger, IOptionsMonitor<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.ArchiveSrvHost, ChannelCredentials.Insecure);
            _client = new ItemSrv.ItemSrvClient(channel);
        }

        [HttpGet("{id}")]
        public Response<ItemInfo> Get(string id)
        {
            return _client.GetItem(new KeyObject() { Body = id });
        }

        [HttpGet]
        public Response<PagedList<ItemDTO>> Get(
            int pageIndex = 1,
            int pageSize = 20,
            string status = "",
            string primarySupplierId = "",
            string itemClsId = "",
            string itemBrandId = "",
            string itemDepartmentId = "",
            string keyword = "")
        {
            var request = new GetItemsRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Status = status,
                PrimarySupplierId = primarySupplierId,
                ItemClsId = itemClsId,
                ItemBrandId = itemBrandId,
                ItemDepartmentId = itemDepartmentId,
                Keyword = keyword
            };
            var response = _client.GetItems(request);

            return new PagedList<ItemDTO>(response.Items, response.TotalCount);
        }

        [HttpPost]
        public Response<ItemInfo> Post(ItemInfo model)
        {
            return _client.CreateItem(model);
        }

        [HttpPut]
        public Response<bool> Put(ItemInfo model)
        {
            return _client.UpdateItem(model).Body;
        }

        [HttpDelete("{id}")]
        public Response<bool> Delete(string id)
        {
            return _client.DeleteItem(new KeyObject() { Body = id }).Body;
        }
    }
}
