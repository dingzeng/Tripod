using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.Mapping
{
    public class StoreMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<StoreDTO,Store>();
            expression.CreateMap<Store,StoreDTO>();
        }
    }
}