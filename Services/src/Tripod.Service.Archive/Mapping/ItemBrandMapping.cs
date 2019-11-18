using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.Mapping
{
    public class ItemBrandMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ItemBrandDTO,ItemBrand>();
            expression.CreateMap<ItemBrand,ItemBrandDTO>();
        }
    }
}