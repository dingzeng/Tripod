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
    /// 商品部门
    /// </summary>
    [ApiController]
    [Route("archive/[controller]")]
    public class ItemDepartmentController: ControllerBase
    {
        private readonly AppOptions _options;
        private readonly ILogger<ItemDepartmentController> _logger;
        private readonly ItemSrv.ItemSrvClient _client;
        public ItemDepartmentController(ILogger<ItemDepartmentController> logger, IOptionsMonitor<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _logger = logger;

            Channel channel = new Channel(_options.ArchiveSrvHost, ChannelCredentials.Insecure);
            _client = new ItemSrv.ItemSrvClient(channel);
        }

        [HttpGet]
        [PermissionFilter("ITEM_DEPARTMENT_VIEW")]
        public Response<PagedList<ItemDepartmentDTO>> Get(int pageIndex = 1, int pageSize = 20)
        {
            var request = new GetItemDepartmentsRequest();
            request.PageIndex = pageIndex;
            request.PageSize = pageSize;

            var response = _client.GetItemDepartments(request);
            return new PagedList<ItemDepartmentDTO>()
            {
                TotalCount = response.TotalCount,
                List = response.ItemDepartments
            };
        }

        [HttpGet("{id}")]
        [PermissionFilter("ITEM_DEPARTMENT_VIEW")]
        public Response<ItemDepartmentDTO> Get(string id)
        {
            return _client.GetItemDepartment(new KeyObject()
            {
                Body = id
            });
        }

        [HttpPost]
        [PermissionFilter("ITEM_DEPARTMENT_CREATE")]
        public Response<ItemDepartmentDTO> Post(ItemDepartmentDTO model) => _client.CreateItemDepartment(model);

        [HttpPut]
        [PermissionFilter("ITEM_DEPARTMENT_UPDATE")]
        public Response<bool> Put(ItemDepartmentDTO model) => _client.UpdateItemDepartment(model).Body;

        [HttpDelete("{id}")]
        [PermissionFilter("ITEM_DEPARTMENT_DELETE")]
        public Response<bool> Delete(string id) => _client.DeleteItemDepartment(new KeyObject() { Body = id }).Body;

        [HttpGet("exists")]
        public Response<bool> Exists(string id)
        {
            return _client.IsExistsItemDepartment(new KeyObject() { Body = id }).Body;
        }
    }
}