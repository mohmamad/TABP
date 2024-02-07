﻿using AutoMapper;
using TABP.API.DTOs.RoomDtos;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.RoomProfile
{
    public class HotelURLResolver : IValueResolver<Room, RoomDto, string>
    {
        public string Resolve(Room source, RoomDto destination, string destMember, ResolutionContext context)
        {
            return $"/api/hotel?hotelId={source.HotelId}";
        }
    }
}
