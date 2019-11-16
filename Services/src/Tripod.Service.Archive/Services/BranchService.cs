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

        public override Task<GetBranchGroupsResponse> GetBranchGroups(Empty request, Grpc.Core.ServerCallContext context)
        {
            var branchGroups = _branchGroupDao.GetAll();
            var response = new GetBranchGroupsResponse();
            response.BranchGroups.AddRange(branchGroups.Select(bg => _mapper.Map<BranchGroupDTO>(bg)));
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

        public override Task<BooleanObject> DeleteBranchGroupBranchs(DeleteBranchGroupBranchsRequest request, Grpc.Core.ServerCallContext context)
        {
            int branchGroupId = Convert.ToInt32(request.BranchGroupId);
            var success = _branchGroupDao.DeleteBranchGroupBranchs(branchGroupId, request.BranchIdList);
            return Task.FromResult(new BooleanObject() { Body = success });
        }

        public override Task<BooleanObject> AddBranchGroupBranchs(AddBranchGroupBranchsRequest request, Grpc.Core.ServerCallContext context)
        {
            int branchGroupId = Convert.ToInt32(request.BranchGroupId);
            var success = _branchGroupDao.AddBranchGroupBranchs(branchGroupId, request.BranchIdList);
            return Task.FromResult(new BooleanObject() { Body = success });
        }
    }
}