using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.Mapping
{
    public class ItemBarcodeMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ItemBarcodeDTO,ItemBarcode>();
            expression.CreateMap<ItemBarcode,ItemBarcodeDTO>();
        }
    }
}