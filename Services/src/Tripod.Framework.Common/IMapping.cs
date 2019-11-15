using System;
using AutoMapper;

namespace Tripod.Framework.Common
{
    public interface IMapping
    {
        void Configure(IMapperConfigurationExpression expression);
    }
}