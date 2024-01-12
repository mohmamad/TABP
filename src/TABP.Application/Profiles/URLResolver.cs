using AutoMapper;
using TABP.Application.Models;
using TABP.Domain.Entities;

namespace TABP.Application.Profiles
{
    public class URLResolver : IValueResolver<User, UserModel, string>
    {
        public string Resolve(User source, UserModel destination, string destMember, ResolutionContext context)
        {
            return $"https://localhost:7183/login"; // TODO add here the link to the user Booking
        }
    }
}
