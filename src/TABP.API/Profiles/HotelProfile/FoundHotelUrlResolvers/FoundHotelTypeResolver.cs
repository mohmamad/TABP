using AutoMapper;
using TABP.API.DTOs.HotelDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.FoundHotelUrlResolver
{
    public class FoundHotelTypeResolver : IValueResolver<Hotel, FoundHotelDto, string>
    {
        public string Resolve(Hotel source, FoundHotelDto destination, string destMember, ResolutionContext context)
        {
            return $"/api/hotel/hotelType/{source.HotelTypeId}";
        }
    }
}
