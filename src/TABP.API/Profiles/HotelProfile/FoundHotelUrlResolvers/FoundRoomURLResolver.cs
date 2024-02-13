using AutoMapper;
using TABP.API.DTOs.HotelDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.FoundHotelUrlResolver
{
    public class FoundRoomURLResolver : IValueResolver<Hotel, FoundHotelDto, string>
    {
        public string Resolve(Hotel source, FoundHotelDto destination, string destMember, ResolutionContext context)
        {
            return $"/api/room?hotelId={source.HotelId}&minPrice=&maxPrice=";
        }
    }
}
