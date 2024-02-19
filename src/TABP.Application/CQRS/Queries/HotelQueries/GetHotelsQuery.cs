﻿using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.HotelQueries
{
    public class GetHotelsQuery : IRequest<Result<IEnumerable<Hotel>>>
    {
        public Guid? HotelId;
        public string? HotelName;
        public string? HotelDescription;
        public double? Rating;
        public string? Amenities;
        public Guid? HotelTypeId;
        public string? HotelType;
        public double? MinPrice;
        public double? MaxPrice;
        public DateTime? StartDate;
        public DateTime? EndDate;
        public string? City;
        public int PageSize;
        public int Page;
    }
}
