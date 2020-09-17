using System;
using Archive.API.Model;
using Archive.API.ViewModel.Item;
using AutoMapper;

namespace Archive.API.MapperProfile
{
    public class ItemModelProfile : Profile
    {
        public ItemModelProfile()
        {
            CreateMap<Item,ItemModel>();

            CreateMap<ItemModel,Item>()
                .ForMember(dest => dest.Category1, opt => opt.Ignore())
                .ForMember(dest => dest.Category2, opt => opt.Ignore())
                .ForMember(dest => dest.Category3, opt => opt.Ignore())
                .ForMember(dest => dest.Brand, opt => opt.Ignore())
                .ForMember(dest => dest.Department, opt => opt.Ignore())
                .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.Supplier.Id))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name));
        }
    }
}