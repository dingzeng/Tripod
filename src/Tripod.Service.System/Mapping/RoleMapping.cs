using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.System.Model;

namespace Tripod.Service.System.Mapping
{
    public class RoleMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<RoleDTO,Role>();
            expression.CreateMap<Role,RoleDTO>();
        }
    }
}