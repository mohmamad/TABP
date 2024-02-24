using AutoMapper;
using TABP.API.DTOs;
using TABP.API.DTOs.UserDtos;
using TABP.Domain.Entities;

namespace TABP.Application.Profiles
{
    public class UserURLResolver : IValueResolver<User, UserDto, List<Link>>
    {
        public List<Link> Resolve(User source, UserDto destination, List<Link> destMember, ResolutionContext context)
        {
            var links = new List<Link>
            {
            new Link { Rel = "booking", Href = $"/api/booking?userId={source.UserId}", Method = "GET" }
            };

            return links;
        }
    }
}
