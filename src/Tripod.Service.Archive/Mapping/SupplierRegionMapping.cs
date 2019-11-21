using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.Mapping
{
    public class SupplierRegionMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<SupplierRegionDTO,SupplierRegion>();
            expression.CreateMap<SupplierRegion,SupplierRegionDTO>();
        }
    }
}