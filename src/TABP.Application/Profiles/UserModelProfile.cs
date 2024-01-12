using AutoMapper;
using TABP.Application.Models;
using TABP.Domain.Entities;

namespace TABP.Application.Profiles
{
    public class UserModelProfile : Profile
    {
        public UserModelProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.BookingUrl, opt => opt.MapFrom<URLResolver>());
                
        }
    }
}
