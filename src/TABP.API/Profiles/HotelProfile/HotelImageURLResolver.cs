using AutoMapper;
using TABP.API.DTOs.HotelDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles
{
    public class HotelImageURLResolver : IValueResolver<Hotel, HotelDto, string>
    {
        public string Resolve(Hotel source, HotelDto destination, string destMember, ResolutionContext context)
        {
            return $"/api/hotel/hotelImage/{source.HotelId}";
        }
    }
}
