using MediatR;
using TABP.API.CQRS.Handlers;

namespace TABP.Application.CQRS.Commands.RoomCommands
{
    public class SaveRoomChangesCommand : IRequest<Result<bool>>
    {
    }
}
