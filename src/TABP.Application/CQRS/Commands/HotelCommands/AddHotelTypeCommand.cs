using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands.HotelCommands
{
    public class AddHotelTypeCommand : IRequest<Result<HotelType>>
    {
        public string HotelType { get; set; }
    }
}
