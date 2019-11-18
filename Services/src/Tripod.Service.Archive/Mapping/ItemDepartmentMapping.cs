using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.Mapping
{
    public class ItemDepartmentMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ItemDepartmentDTO,ItemDepartment>();
            expression.CreateMap<ItemDepartment,ItemDepartmentDTO>();
        }
    }
}