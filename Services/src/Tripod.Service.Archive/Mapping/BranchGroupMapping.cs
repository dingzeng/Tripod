using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.Mapping
{
    public class BranchGroupMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<BranchGroupDTO,BranchGroup>();
            expression.CreateMap<BranchGroup,BranchGroupDTO>();
        }
    }
}