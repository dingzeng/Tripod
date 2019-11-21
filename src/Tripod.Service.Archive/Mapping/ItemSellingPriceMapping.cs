using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.Mapping
{
    public class ItemSellingPriceMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ItemSellingPriceDTO,ItemSellingPrice>();
            expression.CreateMap<ItemSellingPrice,ItemSellingPriceDTO>();
        }
    }
}