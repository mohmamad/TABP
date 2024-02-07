using AutoMapper;
using TABP.API.DTOs.UserDtos;
using TABP.Domain.Entities;

namespace TABP.Application.Profiles
{
    public class UserURLResolver : IValueResolver<User, UserDto, string>
    {
        public string Resolve(User source, UserDto destination, string destMember, ResolutionContext context)
        {
            return $""; // TODO add here the link to the user Booking
        }
    }
}
