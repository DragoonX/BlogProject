using AutoMapper;
using BlogProject.Entities.Concrete;
using BlogProject.Entities.Dtos;
using System;

namespace BlogProject.Services.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(_ => DateTime.Now));
            CreateMap<CategoryUpdateDto, Category>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(_ => DateTime.Now));
            CreateMap<Category, CategoryUpdateDto>();
        }
    }
}
