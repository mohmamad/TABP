using MediatR;
using TABP.API.CQRS.Handlers;

namespace TABP.Application.CQRS.Commands.HotelCommands
{
    public class DeleteHotelCommand : IRequest<Result<string>>
    {
        public Guid HotelId { get; set; }
    }
}
