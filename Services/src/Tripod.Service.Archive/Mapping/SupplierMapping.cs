using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.Mapping
{
    public class SupplierMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<SupplierDTO,Supplier>();
            expression.CreateMap<Supplier,SupplierDTO>();
        }
    }
}