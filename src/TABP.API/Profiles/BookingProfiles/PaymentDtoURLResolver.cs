using AutoMapper;
using TABP.API.DTOs.BookingDtos;
using TABP.API.DTOs;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.BookingProfiles
{
    public class PaymentDtoURLResolver : IValueResolver<AddBookingDto, PaymentDto, List<Link>>
    {
        public List<Link> Resolve(AddBookingDto source, PaymentDto destination, List<Link> destMember, ResolutionContext context)
        {
            var links = new List<Link>
            {
            new Link { Rel = "room", Href = $"/api/room?roomId={source.RoomId}", Method = "GET" }
            };

            return links;
        }
    }
}
