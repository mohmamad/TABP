using AutoMapper;
using TABP.API.DTOs;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.RoomProfile
{
    public class BookingURLResolver : IValueResolver<Room, RoomDto, string>
    {
        public string Resolve(Room source, RoomDto destination, string destMember, ResolutionContext context)
        {
            return $"get booking by room id url";
        }
    }
}
