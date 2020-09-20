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
            CreateMap<Item,ItemModel>()
                .ForMember(dest => dest.CategoryName3, opt => opt.MapFrom(src => src.Category3.Name))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                ;

            CreateMap<ItemModel,Item>();
        }
    }
}