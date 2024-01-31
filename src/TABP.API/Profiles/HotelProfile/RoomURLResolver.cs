using AutoMapper;
using TABP.API.DTOs;
using TABP.Domain.Entities;

namespace TABP.API.Profiles
{
    public class RoomURLResolver : IValueResolver<Hotel, HotelDto, string>
    {
        public string Resolve(Hotel source, HotelDto destination, string destMember, ResolutionContext context)
        {
            return $"https://localhost:7183/api/room?pageSize=30&hotelId={source.HotelId}";
        }
    }
}
