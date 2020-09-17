using System;
using AutoMapper;
using Purchase.API.Model;
using Purchase.API.ViewModel;

namespace Purchase.API.MapperProfile
{
    public class SupplierModelProfile : Profile
    {
        public SupplierModelProfile()
        {
            CreateMap<Supplier,SupplierModel>();

            CreateMap<SupplierModel,Supplier>()
                .ForMember(dest => dest.Region, opt => opt.Ignore())
                .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.Region.Id));
        }
    }
}