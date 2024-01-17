using AutoMapper;
using TABP.API.DTOs;
using TABP.Domain.Entities;

namespace TABP.Application.Profiles
{
    public class URLResolver : IValueResolver<User, UserDto, string>
    {
        public string Resolve(User source, UserDto destination, string destMember, ResolutionContext context)
        {
            return $"https://localhost:7183/login"; // TODO add here the link to the user Booking
        }
    }
}
