using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.System.Model;

namespace Tripod.Service.System.Mapping
{
    public class PermissionApiMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<PermissionApiDTO,PermissionApi>();
            expression.CreateMap<PermissionApi,PermissionApiDTO>();
        }
    }
}