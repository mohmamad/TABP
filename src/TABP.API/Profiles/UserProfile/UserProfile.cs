using AutoMapper;
using TABP.API.DTOs.UserDtos;
using TABP.Application.Profiles;
using TABP.Domain.Entities;

namespace TABP.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserDto>()
               .ForMember(dest => dest.BookingUrl, opt => opt.MapFrom<UserURLResolver>());
        }
    }
}
