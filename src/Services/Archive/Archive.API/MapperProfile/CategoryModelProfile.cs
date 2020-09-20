using System;
using Archive.API.Model;
using Archive.API.ViewModel;
using AutoMapper;

namespace Archive.API.MapperProfile
{
	public class CategoryModelProfile : Profile
	{
		public CategoryModelProfile()
		{
			CreateMap<CategoryModel,Category>();
			CreateMap<Category,CategoryModel>()
				.ForMember(desc => desc.ParentName, opt => opt.MapFrom(src => src.Parent.Name));
		}
	}
}