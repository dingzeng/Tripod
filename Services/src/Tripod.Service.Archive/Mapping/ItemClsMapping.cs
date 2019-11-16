using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.Mapping
{
    public class ItemClsMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ItemClsDTO,ItemCls>();
            expression.CreateMap<ItemCls,ItemClsDTO>();
        }
    }
}