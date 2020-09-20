using System;
using Archive.API.Model;
using Archive.API.ViewModel;
using AutoMapper;

namespace Archive.API.MapperProfile
{
	public class BranchModelProfile : Profile
	{
		public BranchModelProfile()
		{
			CreateMap<BranchModel,Branch>();
			
			CreateMap<Branch,BranchModel>()
				.ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent.Name));
		}
	}
}