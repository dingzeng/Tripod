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
    public class SupplierService : SupplierSrv.SupplierSrvBase
    {
        private readonly SupplierRegionDAO _supplierRegionDao;
        private readonly SupplierDAO _supplierDao;
        private readonly IMapper _mapper;
        public SupplierService(IMapper mapper, ConfigurationOptions options)
        {
            _supplierRegionDao = new SupplierRegionDAO(options);
            _supplierDao = new SupplierDAO(options);
            _mapper = mapper;
        }

        public override Task<GetSupplierRegionsResponse> GetSupplierRegions(Empty request, ServerCallContext context)
        {
            var supplierRegions = _supplierRegionDao.GetAll();
            var response = new GetSupplierRegionsResponse();
            response.SupplierRegions.AddRange(supplierRegions.Select(sr => _mapper.Map<SupplierRegionDTO>(sr)));
            return Task.FromResult(response);
        }

        public override Task<SupplierRegionDTO> GetSupplierRegion(KeyObject request, ServerCallContext context)
        {
            var supplierRegion = _supplierRegionDao.Get(request.Body);
            return Task.FromResult(_mapper.Map<SupplierRegionDTO>(supplierRegion));
        }

        public override Task<SupplierRegionDTO> CreateSupplierRegion(SupplierRegionDTO request, ServerCallContext context)
        {
            var id = _supplierRegionDao.Insert(_mapper.Map<SupplierRegion>(request));
            var supplierRegion = _supplierRegionDao.Get(id);
            return Task.FromResult(_mapper.Map<SupplierRegionDTO>(supplierRegion));
        }

        public override Task<BooleanObject> UpdateSupplierRegion(SupplierRegionDTO request, ServerCallContext context)
        {
            var success = _supplierRegionDao.Update(_mapper.Map<SupplierRegion>(request));
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<BooleanObject> DeleteSupplierRegion(KeyObject request, ServerCallContext context)
        {
            var id = Convert.ToInt32(request.Body);
            var success = _supplierRegionDao.Delete(new SupplierRegion() { Id = id });
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<GetSuppliersResponse> GetSuppliers(GetSuppliersRequest request, ServerCallContext context)
        {
            var suppliers = _supplierDao.GetSuppliers(pageIndex: request.PageIndex, pageSize: request.PageSize, supplierRegionId: request.SupplierRegionId);
            var response = new GetSuppliersResponse();
            response.Suppliers.AddRange(suppliers.List.Select(s => _mapper.Map<SupplierDTO>(s)));
            response.TotalCount = suppliers.TotalCount;
            return Task.FromResult(response);
        }

        public override Task<SupplierDTO> GetSupplier(KeyObject request, ServerCallContext context)
        {
            var supplier = _supplierDao.Get(request.Body);
            return Task.FromResult(_mapper.Map<SupplierDTO>(supplier));
        }

        public override Task<SupplierDTO> CreateSupplier(SupplierDTO request, ServerCallContext context)
        {
            var id = _supplierDao.Insert(_mapper.Map<Supplier>(request));
            var supplier = _supplierDao.Get(id);
            return Task.FromResult(_mapper.Map<SupplierDTO>(supplier));
        }

        public override Task<BooleanObject> UpdateSupplier(SupplierDTO request, ServerCallContext context)
        {
            var success = _supplierDao.Update(_mapper.Map<Supplier>(request));
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<BooleanObject> DeleteSupplier(KeyObject request, ServerCallContext context)
        {
            var success = _supplierDao.Delete(new Supplier() { Id = request.Body });
            return Task.FromResult(new BooleanObject() { Body = success });
        }
    }
}