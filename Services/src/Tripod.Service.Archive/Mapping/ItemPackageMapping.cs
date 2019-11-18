using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.Mapping
{
    public class ItemPackageMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ItemPackageDTO,ItemPackage>();
            expression.CreateMap<ItemPackage,ItemPackageDTO>();
        }
    }
}