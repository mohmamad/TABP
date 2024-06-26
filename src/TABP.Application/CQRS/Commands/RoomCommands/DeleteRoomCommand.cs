using MediatR;
using TABP.API.CQRS.Handlers;

namespace TABP.Application.CQRS.Commands.RoomCommands
{
    public class DeleteRoomCommand : IRequest<Result<string>>
    {
        public Guid RoomId { get; set; }
    }
}
