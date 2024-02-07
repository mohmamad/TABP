using MediatR;
using TABP.API.CQRS.Handlers;

namespace TABP.Application.CQRS.Commands.HotelCommands
{
    public class SaveHotelChangesCommand : IRequest<Result<bool>>
    {

    }
}
