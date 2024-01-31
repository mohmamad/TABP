﻿using AutoMapper;
using TABP.API.DTOs;
using TABP.Domain.Entities;

namespace TABP.API.Profiles.RoomProfile
{
    public class RoomTypeURLResolver : IValueResolver<Room, RoomDto, string>
    {
        public string Resolve(Room source, RoomDto destination, string destMember, ResolutionContext context)
        {
            return $"https://localhost:7183/api/room/roomType/{source.RoomTypeId}";
        }
    }
}