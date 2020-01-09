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
    public class BranchService : BranchSrv.BranchSrvBase
    {
        private readonly IMapper _mapper;
        private readonly BranchDAO _branchDao;
        private readonly BranchGroupDAO _branchGroupDao;
        public BranchService(IMapper mapper, ConfigurationOptions options)
        {
            _mapper = mapper;
            _branchDao = new BranchDAO(options);
            _branchGroupDao = new BranchGroupDAO(options);
        }

        public override Task<GetBranchGroupsResponse> GetBranchGroups(GetBranchGroupsRequest request, Grpc.Core.ServerCallContext context)
        {
            var branchGroups = _branchGroupDao.GetBranchGroups(request.PageIndex, request.PageSize, request.Keyword);
            var response = new GetBranchGroupsResponse();

            response.BranchGroups.AddRange(branchGroups.List.Select(bg => _mapper.Map<BranchGroupDTO>(bg)));
            response.TotalCount = branchGroups.TotalCount;
            return Task.FromResult(response);
        }

        public override Task<BranchGroupDTO> GetBranchGroup(KeyObject request, Grpc.Core.ServerCallContext context)
        {
            int id = Convert.ToInt32(request.Body);
            var branchGroup = _branchGroupDao.Get(id);
            return Task.FromResult(_mapper.Map<BranchGroupDTO>(branchGroup));
        }

        public override Task<BranchGroupDTO> CreateBranchGroup(BranchGroupDTO request, Grpc.Core.ServerCallContext context)
        {
            var id = _branchGroupDao.Insert(_mapper.Map<BranchGroup>(request));
            var branchGroup = _branchGroupDao.Get(id);
            return Task.FromResult(_mapper.Map<BranchGroupDTO>(branchGroup));
        }

        public override Task<BooleanObject> UpdateBranchGroup(BranchGroupDTO request, Grpc.Core.ServerCallContext context)
        {
            var success = _branchGroupDao.Update(_mapper.Map<BranchGroup>(request));
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<BooleanObject> DeleteBranchGroup(KeyObject request, Grpc.Core.ServerCallContext context)
        {
            var branchGroup = new BranchGroup()
            {
                Id = Convert.ToInt32(request.Body)
            };
            var success = _branchGroupDao.Delete(branchGroup);
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<GetBranchGroupBranchsResponse> GetBranchGroupBranchs(KeyObject request, Grpc.Core.ServerCallContext context)
        {
            var branchGroupId = Convert.ToInt32(request.Body);
            var branchs = _branchDao.GetBranchGroupBranchs(branchGroupId);
            var response = new GetBranchGroupBranchsResponse();
            response.BranchGroupBranchs.AddRange(branchs.Select(b => _mapper.Map<BranchDTO>(b)));
            return Task.FromResult(response);
        }

        public override Task<BooleanObject> UpdateBranchGroupBranchs(UpdateBranchGroupBranchsRequest request, ServerCallContext context)
        {
            var success = _branchGroupDao.UpdateBranchGroupBranchs(request.BranchGroupId, request.BranchIdList);

            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<GetBranchsResponse> GetBranchs(GetBranchsRequest request, ServerCallContext context)
        {
            var branchs = _branchDao.GetBranchs(request.PageIndex, request.PageSize, request.Keyword, request.ParentId, request.TypeList);
            var response = new GetBranchsResponse();
            response.TotalCount = branchs.TotalCount;
            response.Branchs.AddRange(branchs.List.Select(b => _mapper.Map<BranchDTO>(b)));
            return Task.FromResult(response);
        }

        public override Task<BranchDTO> GetBranch(KeyObject request, ServerCallContext context)
        {
            var branch = _branchDao.Get(request.Body);
            return Task.FromResult(_mapper.Map<BranchDTO>(branch));
        }

        public override Task<BranchDTO> CreateBranch(BranchDTO request, ServerCallContext context)
        {
            var id = _branchDao.Insert(_mapper.Map<Branch>(request));
            var branch = _branchDao.Get(id);
            return Task.FromResult(_mapper.Map<BranchDTO>(branch));
        }

        public override Task<BooleanObject> UpdateBranch(BranchDTO request, ServerCallContext context)
        {
            var success = _branchDao.Update(_mapper.Map<Branch>(request));
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<BooleanObject> DeleteBranch(KeyObject request, ServerCallContext context)
        {
            var success = _branchDao.Delete(new Branch() { Id = request.Body });
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<GetBranchStoresResponse> GetBranchStores(KeyObject request, ServerCallContext context)
        {
            var stores = _branchDao.GetStoresByBranchId(request.Body);
            var resposne = new GetBranchStoresResponse();
            resposne.Stores.AddRange(stores.Select(s => _mapper.Map<StoreDTO>(s)));
            return Task.FromResult(resposne);
        }

        public override Task<BooleanObject> UpdateBranchStores(UpdateBranchStoresRequest request, ServerCallContext context)
        {
            var stores = request.Stores.Select(s => _mapper.Map<Store>(s)).ToList();
            var success = _branchDao.UpdateBranchStores(request.BranchId, stores);
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<BooleanObject> IsExistsBranch(KeyObject request, ServerCallContext context)
        {
            var branch = _branchDao.Get(request.Body);
            return Task.FromResult(new BooleanObject() { Body = branch != null });
        }
    }
}