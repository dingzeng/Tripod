using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Tripod.Service.Archive.DAL;
using Tripod.Service.Archive.Model;
using Tripod.Framework.Common;
using AutoMapper;

namespace Tripod.Service.Archive.Services
{
    public class ItemService : ItemSrv.ItemSrvBase
    {
        private readonly ItemBrandDAO _itemBrandDao;
        private readonly ItemClsDAO _itemClsDao;
        private readonly ItemUnitDAO _itemUnitDao;
        private readonly ItemDepartmentDAO _itemDepartmentDao;
        private readonly ItemDAO _itemDao;
        private readonly IMapper _mapper;
        public ItemService(IMapper mapper, ConfigurationOptions options)
        {
            _mapper = mapper;
            _itemBrandDao = new ItemBrandDAO(options);
            _itemClsDao = new ItemClsDAO(options);
            _itemUnitDao = new ItemUnitDAO(options);
            _itemDepartmentDao = new ItemDepartmentDAO(options);
            _itemDao = new ItemDAO(options);
        }

        // itemCls
        public override Task<GetItemClssResponse> GetItemClss(GetItemClssRequest request, ServerCallContext context)
        {
            var itemClss = _itemClsDao.GetItemClss(pageIndex: request.PageIndex, pageSize: request.PageSize, parentId: request.ParentId);
            var response = new GetItemClssResponse();
            response.TotalCount = itemClss.TotalCount;
            response.ItemClss.AddRange(itemClss.List.Select(ic => _mapper.Map<ItemClsDTO>(ic)));
            return Task.FromResult(response);
        }

        public override Task<ItemClsDTO> GetItemCls(KeyObject request, ServerCallContext context)
        {
            var itemCls = _itemClsDao.Get(request.Body);
            return Task.FromResult(_mapper.Map<ItemClsDTO>(itemCls));
        }

        public override Task<ItemClsDTO> CreateItemCls(ItemClsDTO request, ServerCallContext context)
        {
            var id = _itemClsDao.Insert(_mapper.Map<ItemCls>(request));
            var itemCls = _itemClsDao.Get(id);
            return Task.FromResult(_mapper.Map<ItemClsDTO>(itemCls));
        }

        public override Task<BooleanObject> UpdateItemCls(ItemClsDTO request, ServerCallContext context)
        {
            var success = _itemClsDao.Update(_mapper.Map<ItemCls>(request));
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<BooleanObject> DeleteItemCls(KeyObject request, ServerCallContext context)
        {
            var success = _itemClsDao.Delete(new ItemCls() { Id = request.Body });
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        // itemBrand
        public override Task<GetItemBrandsResponse> GetItemBrands(Empty request, ServerCallContext context)
        {
            var itemBrands = _itemBrandDao.GetAll();
            var response = new GetItemBrandsResponse();
            response.ItemBrands.AddRange(itemBrands.Select(ib => _mapper.Map<ItemBrandDTO>(ib)));
            return Task.FromResult(response);
        }

        public override Task<ItemBrandDTO> GetItemBrand(KeyObject request, ServerCallContext context)
        {
            var itemBrand = _itemBrandDao.Get(request.Body);
            return Task.FromResult(_mapper.Map<ItemBrandDTO>(itemBrand));
        }

        public override Task<ItemBrandDTO> CreateItemBrand(ItemBrandDTO request, ServerCallContext context)
        {
            var id = _itemBrandDao.Insert(_mapper.Map<ItemBrand>(request));
            var itemBrand = _itemBrandDao.Get(id);
            return Task.FromResult(_mapper.Map<ItemBrandDTO>(itemBrand));
        }

        public override Task<BooleanObject> DeleteItemBrand(KeyObject request, ServerCallContext context)
        {
            var success = _itemBrandDao.Delete(new ItemBrand() { Id = request.Body });
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<BooleanObject> UpdateItemBrand(ItemBrandDTO request, ServerCallContext context)
        {
            var success = _itemBrandDao.Update(_mapper.Map<ItemBrand>(request));
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        // itemUnit
        public override Task<GetItemUnitResponse> GetItemUnits(Empty request, ServerCallContext context)
        {
            var itemUnits = _itemUnitDao.GetAll();
            var response = new GetItemUnitResponse();
            response.ItemUnits.AddRange(itemUnits.Select(iu => _mapper.Map<ItemUnitDTO>(iu)));
            return Task.FromResult(response);
        }

        public override Task<ItemUnitDTO> GetItemUnit(KeyObject request, ServerCallContext context)
        {
            var itemUnit = _itemUnitDao.Get(request.Body);
            return Task.FromResult(_mapper.Map<ItemUnitDTO>(itemUnit));
        }

        public override Task<ItemUnitDTO> CreateItemUnit(ItemUnitDTO request, ServerCallContext context)
        {
            var id = _itemUnitDao.Insert(_mapper.Map<ItemUnit>(request));
            var itemUnit = _itemUnitDao.Get(id);
            return Task.FromResult(_mapper.Map<ItemUnitDTO>(itemUnit));
        }

        public override Task<BooleanObject> UpdateItemUnit(ItemUnitDTO request, ServerCallContext context)
        {
            var success = _itemUnitDao.Update(_mapper.Map<ItemUnit>(request));
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<BooleanObject> DeleteItemUnit(KeyObject request, ServerCallContext context)
        {
            var id = Convert.ToInt32(request.Body);
            var success = _itemUnitDao.Update(new ItemUnit() { Id = id });
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        // itemDepartment
        public override Task<GetItemDepartmentsResponse> GetItemDepartments(Empty request, ServerCallContext context)
        {
            var itemDepartments = _itemDepartmentDao.GetAll();
            var response = new GetItemDepartmentsResponse();
            response.ItemDepartments.AddRange(itemDepartments.Select(id => _mapper.Map<ItemDepartmentDTO>(id)));
            return Task.FromResult(response);
        }

        public override Task<ItemDepartmentDTO> GetItemDepartment(KeyObject request, ServerCallContext context)
        {
            var itemDepartment = _itemDepartmentDao.Get(request.Body);
            return Task.FromResult(_mapper.Map<ItemDepartmentDTO>(itemDepartment));
        }

        public override Task<ItemDepartmentDTO> CreateItemDepartment(ItemDepartmentDTO request, ServerCallContext context)
        {
            var id = _itemDepartmentDao.Insert(_mapper.Map<ItemDepartment>(request));
            var itemDepartment = _itemDepartmentDao.Get(id);
            return Task.FromResult(_mapper.Map<ItemDepartmentDTO>(itemDepartment));
        }

        public override Task<BooleanObject> UpdateItemDepartment(ItemDepartmentDTO request, ServerCallContext context)
        {
            var success = _itemDepartmentDao.Update(_mapper.Map<ItemDepartment>(request));
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<BooleanObject> DeleteItemDepartment(KeyObject request, ServerCallContext context)
        {
            var id = Convert.ToInt32(request.Body);
            var success = _itemDepartmentDao.Update(new ItemDepartment() { Id = id });
            return Task.FromResult(new BooleanObject() { Body = success });
        }
    }
}