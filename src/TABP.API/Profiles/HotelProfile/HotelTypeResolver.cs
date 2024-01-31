using AutoMapper;
using TABP.API.DTOs;
using TABP.Domain.Entities;

namespace TABP.API.Profiles
{
    public class HotelTypeResolver : IValueResolver<Hotel, HotelDto, string>
    {
        public string Resolve(Hotel source, HotelDto destination, string destMember, ResolutionContext context)
        {
            return $"get hotel type url";
        }
    }
}
