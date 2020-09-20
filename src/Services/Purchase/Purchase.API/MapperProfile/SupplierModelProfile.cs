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
            CreateMap<Supplier,SupplierModel>()
                .ForMember(dest => dest.RegionName, opt => opt.MapFrom(src => src.Region.Name));

            CreateMap<SupplierModel,Supplier>();
        }
    }
}