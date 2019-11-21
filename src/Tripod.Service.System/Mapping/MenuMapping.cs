using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.System.Model;

namespace Tripod.Service.System.Mapping
{
    public class MenuMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<MenuDTO,Menu>();
            expression.CreateMap<Menu,MenuDTO>();
        }
    }
}