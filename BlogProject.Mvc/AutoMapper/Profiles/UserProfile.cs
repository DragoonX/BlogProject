using AutoMapper;
using BlogProject.Entities.Concrete;
using BlogProject.Entities.Dtos;

namespace BlogProject.Mvc.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}
