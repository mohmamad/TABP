using AutoMapper;
using TABP.API.DTOs.BookingDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.BookingProfiles
{
    public class RoomURLResolver : IValueResolver<Booking, BookingDto, string>
    {
        public string Resolve(Booking source, BookingDto destination, string destMember, ResolutionContext context)
        {
            return $"/api/room?roomId={source.RoomId}";
        }
    }
}
