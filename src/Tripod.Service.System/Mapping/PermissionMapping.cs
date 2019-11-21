using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.System.Model;

namespace Tripod.Service.System.Mapping
{
    public class PermissionMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<PermissionDTO,Permission>();
            expression.CreateMap<Permission,PermissionDTO>();
        }
    }
}