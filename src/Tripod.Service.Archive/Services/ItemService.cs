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
        private readonly ItemBarcodeDAO _itemBarcodeDao;
        private readonly ItemSubDAO _itemSubDao;
        private readonly ItemPackageDAO _itemPackageDao;
        private readonly IMapper _mapper;
        public ItemService(IMapper mapper, ConfigurationOptions options)
        {
            _mapper = mapper;
            _itemBrandDao = new ItemBrandDAO(options);
            _itemClsDao = new ItemClsDAO(options);
            _itemUnitDao = new ItemUnitDAO(options);
            _itemDepartmentDao = new ItemDepartmentDAO(options);
            _itemDao = new ItemDAO(options);
            _itemBarcodeDao = new ItemBarcodeDAO(options);
            _itemSubDao = new ItemSubDAO(options);
            _itemPackageDao = new ItemPackageDAO(options);
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
            _itemClsDao.Insert(_mapper.Map<ItemCls>(request));
            var itemCls = _itemClsDao.Get(request.Id);
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

        public override Task<BooleanObject> IsExistsItemCls(KeyObject request, ServerCallContext context)
        {
            var exists = _itemClsDao.Get(request.Body);
            return Task.FromResult(new BooleanObject() { Body = exists != null });
        }

        // itemBrand
        public override Task<GetItemBrandsResponse> GetItemBrands(GetItemBrandsRequest request, ServerCallContext context)
        {
            var itemBrands = _itemBrandDao.GetPaging(pageIndex: request.PageIndex, pageSize: request.PageSize);

            var response = new GetItemBrandsResponse();
            response.TotalCount = itemBrands.TotalCount;
            response.ItemBrands.AddRange(itemBrands.List.Select(ib => _mapper.Map<ItemBrandDTO>(ib)));
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

        public override Task<BooleanObject> IsExistsItemBrand(KeyObject request, ServerCallContext context)
        {
            var exists = _itemBrandDao.Get(request.Body);
            return Task.FromResult(new BooleanObject() { Body = exists != null });
        }

        // itemUnit
        public override Task<GetItemUnitResponse> GetItemUnits(GetItemUnitsRequest request, ServerCallContext context)
        {
            var itemUnits = _itemUnitDao.GetPaging(request.PageIndex, request.PageSize);

            var response = new GetItemUnitResponse();
            response.TotalCount = itemUnits.TotalCount;
            response.ItemUnits.AddRange(itemUnits.List.Select(iu => _mapper.Map<ItemUnitDTO>(iu)));
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
            var success = _itemUnitDao.Delete(new ItemUnit() { Id = id });
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<BooleanObject> IsExistsItemUnit(KeyObject request, ServerCallContext context)
        {
            var exists = _itemUnitDao.Get(request.Body);
            return Task.FromResult(new BooleanObject() { Body = exists != null });
        }

        // itemDepartment
        public override Task<GetItemDepartmentsResponse> GetItemDepartments(GetItemDepartmentsRequest request, ServerCallContext context)
        {
            var itemDepartments = _itemDepartmentDao.GetPaging(request.PageIndex, request.PageSize);

            var response = new GetItemDepartmentsResponse();
            response.TotalCount = itemDepartments.TotalCount;
            response.ItemDepartments.AddRange(itemDepartments.List.Select(id => _mapper.Map<ItemDepartmentDTO>(id)));
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

        public override Task<BooleanObject> IsExistsItemDepartment(KeyObject request, ServerCallContext context)
        {
            var exists = _itemDepartmentDao.Get(request.Body);
            return Task.FromResult(new BooleanObject() { Body = exists != null });
        }

        // item
        public override Task<ItemInfo> GetItem(KeyObject request, ServerCallContext context)
        {
            var itemId = request.Body;

            var response = new ItemInfo();
            var item = _itemDao.Get(itemId);
            var barcodes = _itemBarcodeDao.GetItemBarcodesByItemId(itemId);
            var subs = _itemSubDao.GetItemSubsByItemId(itemId);
            var packages = _itemPackageDao.GetItemPackagesByItemId(itemId);

            response.Item = _mapper.Map<ItemDTO>(item);
            response.Barcodes.AddRange(barcodes.Select(b => _mapper.Map<ItemBarcodeDTO>(b)));
            response.Packages.AddRange(packages.Select(p => _mapper.Map<ItemPackageDTO>(p)));
            response.Subs.AddRange(subs.Select(s => _mapper.Map<ItemSubDTO>(s)));

            return Task.FromResult(response);
        }

        public override Task<GetItemsResponse> GetItems(GetItemsRequest request, ServerCallContext context)
        {
            var page = _itemDao.Query(
                 pageIndex: request.PageIndex,
                 pageSize: request.PageSize,
                 status: request.Status,
                 primarySupplierId: request.PrimarySupplierId,
                 itemClsId: request.ItemClsId,
                 itemBrandId: request.ItemBrandId,
                 itemDepartmentId: request.ItemDepartmentId,
                 keyword: request.Keyword);

            var response = new GetItemsResponse();
            response.Items.AddRange(page.List.Select(item => _mapper.Map<ItemDTO>(item)));
            response.TotalCount = page.TotalCount;

            return Task.FromResult(response);
        }

        public override Task<ItemInfo> CreateItem(ItemInfo request, ServerCallContext context)
        {
            var item = _mapper.Map<Item>(request.Item);
            var barcodes = request.Barcodes.Select(b => _mapper.Map<ItemBarcode>(b)).ToList();
            var packages = request.Packages.Select(p => _mapper.Map<ItemPackage>(p)).ToList();
            var subs = request.Subs.Select(sub => _mapper.Map<ItemSub>(sub)).ToList();

            var itemInfo = new Tuple<Item, List<ItemBarcode>, List<ItemPackage>, List<ItemSub>>(item, barcodes, packages, subs);

            _itemDao.CreateItem(itemInfo);

            return GetItem(new KeyObject() { Body = item.Id }, context);
        }

        public override Task<BooleanObject> DeleteItem(KeyObject request, ServerCallContext context)
        {
            var success = _itemDao.Delete(new Item() { Id = request.Body });
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<BooleanObject> IsExistsItemId(KeyObject request, ServerCallContext context)
        {
            bool exists = _itemDao.Get(request.Body) != null;
            return Task.FromResult(new BooleanObject() { Body = exists });
        }

        public override Task<BooleanObject> IsExistsItemBarcode(KeyObject request, ServerCallContext context)
        {
            bool exists = _itemBarcodeDao.IsExistsItemBarcode(request.Body);
            return Task.FromResult(new BooleanObject() { Body = exists });
        }

        public override Task<BooleanObject> UpdateItem(ItemInfo request, ServerCallContext context)
        {
            var item = _mapper.Map<Item>(request.Item);
            var barcodes = request.Barcodes.Select(b => _mapper.Map<ItemBarcode>(b)).ToList();
            var packages = request.Packages.Select(p => _mapper.Map<ItemPackage>(p)).ToList();
            var subs = request.Subs.Select(sub => _mapper.Map<ItemSub>(sub)).ToList();

            var itemInfo = new Tuple<Item, List<ItemBarcode>, List<ItemPackage>, List<ItemSub>>(item, barcodes, packages, subs);

            var success = _itemDao.UpdateItem(itemInfo);

            return Task.FromResult(new BooleanObject() { Body = success });
        }
    }
}