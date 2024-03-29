﻿using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.HotelQueries
{
    public class GetHotelByIdQuery : IRequest<Result<Hotel>>
    {
        public Guid HotelId { get; set; }
    }
}
