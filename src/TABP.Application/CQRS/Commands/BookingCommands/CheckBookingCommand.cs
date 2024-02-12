﻿using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands.BookingCommands
{
    public class CheckBookingCommand : IRequest<Result<double>>
    {
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfResidents { get; set; }
    }
}
