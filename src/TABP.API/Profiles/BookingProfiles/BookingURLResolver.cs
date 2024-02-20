using AutoMapper;
using TABP.API.DTOs;
using TABP.API.DTOs.BookingDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.BookingProfiles
{
    public class BookingURLResolver : IValueResolver<Booking, BookingDto, List<Link>>
    {
        public List<Link> Resolve(Booking source, BookingDto destination, List<Link> destMember, ResolutionContext context)
        {
            var links = new List<Link>
            {
            new Link { Rel = "user", Href = $"/api/users?userId={source.UserId}", Method = "GET" },
            new Link { Rel = "rooms", Href = $"/api/room?roomId={source.RoomId}", Method = "GET" }
            };

            return links;
        }
    }
}
