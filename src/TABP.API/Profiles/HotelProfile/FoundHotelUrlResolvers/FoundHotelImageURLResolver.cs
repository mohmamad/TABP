using AutoMapper;
using TABP.API.DTOs.HotelDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.FoundHotelUrlResolver
{
    public class FoundHotelImageURLResolver : IValueResolver<Hotel, FoundHotelDto, string>
    {
        public string Resolve(Hotel source, FoundHotelDto destination, string destMember, ResolutionContext context)
        {
            return $"/api/hotel/hotelImage/{source.HotelId}";
        }
    }
}
