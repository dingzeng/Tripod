using System;
using AutoMapper;
using Tripod.Framework.Common;
using Tripod.Service.System.Model;

namespace Tripod.Service.System.Mapping
{
    public class UserMapping : IMapping
    {
        public void Configure(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<UserDTO,User>();
            expression.CreateMap<User,UserDTO>();
        }
    }
}