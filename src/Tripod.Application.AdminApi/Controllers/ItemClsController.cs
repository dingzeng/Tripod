using System;
using System.Collections.Generic;
using System.Linq;
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
    /// 商品类别
    /// </summary>
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
        [PermissionFilter("ITEM_CLS_VIEW")]
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
        [PermissionFilter("ITEM_CLS_VIEW")]
        public Response<ItemClsDTO> Get(string id)
        {
            return _client.GetItemCls(new KeyObject()
            {
                Body = id
            });
        }

        [HttpPost]
        [PermissionFilter("ITEM_CLS_CREATE")]
        public Response<ItemClsDTO> Post(ItemClsDTO model) => _client.CreateItemCls(model);

        [HttpPut]
        [PermissionFilter("ITEM_CLS_UPDATE")]
        public Response<bool> Put(ItemClsDTO model) => _client.UpdateItemCls(model).Body;

        [HttpDelete("{id}")]
        [PermissionFilter("ITEM_CLS_DELETE")]
        public Response<bool> Delete(string id) => _client.DeleteItemCls(new KeyObject() { Body = id }).Body;

        [HttpGet("exists")]
        public Response<bool> Exists(string id)
        {
            return _client.IsExistsItemCls(new KeyObject() { Body = id }).Body;
        }

        [HttpGet("tree")]
        public Response<List<TreeNode>> Tree()
        {
            var root = new TreeNode();
            root.Id = "";
            root.Label = "全部";

            Func<ItemClsDTO, TreeNode> convert = (itemCls) =>
            {
                return new TreeNode()
                {
                    Id = itemCls.Id,
                    Label = itemCls.Name,
                    Children = new List<TreeNode>()
                };
            };

            root.Children = new List<TreeNode>();

            var itemClss = _client.GetItemClss(new GetItemClssRequest() { PageIndex = 1, PageSize = int.MaxValue });
            var firstLevelItemClss = itemClss.ItemClss.Where(ic => string.IsNullOrEmpty(ic.ParentId));
            foreach (var first in firstLevelItemClss)
            {
                root.Children.Add(convert(first));
                foreach (var second in itemClss.ItemClss.Where(ic => ic.ParentId == first.Id))
                {
                    root.Children.Add(convert(second));
                    foreach (var third in itemClss.ItemClss.Where(ic => ic.ParentId == second.Id))
                    {
                        root.Children.Add(convert(second));
                    }
                }
            }

            return new List<TreeNode>() { root };
        }
    }
}