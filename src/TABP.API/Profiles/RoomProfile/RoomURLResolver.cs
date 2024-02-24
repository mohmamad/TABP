using AutoMapper;
using TABP.API.DTOs;
using TABP.API.DTOs.RoomDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.RoomProfile
{
    public class RoomURLResolver : IValueResolver<Room, RoomDto, List<Link>>
    {
        public List<Link> Resolve(Room source, RoomDto destination, List<Link> destMember, ResolutionContext context)
        {
            var links = new List<Link>
            {
            new Link { Rel = "room type", Href = $"/api/room/roomType/{source.RoomTypeId}", Method = "GET" },
            new Link { Rel = "hotel", Href = $"/api/hotel?hotelId={source.HotelId}", Method = "GET" },
            new Link { Rel = "booking", Href = $"/api/booking?roomId={source.RoomId}", Method = "GET" }
            };

            return links;
        }
    }
}
