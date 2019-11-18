using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.Mapping
{
    public class ItemDeliveryPriceMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ItemDeliveryPriceDTO,ItemDeliveryPrice>();
            expression.CreateMap<ItemDeliveryPrice,ItemDeliveryPriceDTO>();
        }
    }
}