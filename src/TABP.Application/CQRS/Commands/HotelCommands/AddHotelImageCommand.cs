using MediatR;
using Microsoft.AspNetCore.Http;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands.HotelCommands
{
    public class AddHotelImageCommand : IRequest<Result<HotelImage>>
    {
        public Guid HotelId { get; set; }
        public string HotelImagePath { get; set; }
    }
}
