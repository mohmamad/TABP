using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.RoomCommands;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.RoomHandlers
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, Result<string>>
    {
        private readonly IRoomRepository _roomRepository;
        public DeleteRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<Result<string>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            await _roomRepository.DeleteRoom(request.RoomId);
            return Result<string>.Success("Room Deleted Successfully.");
        }
    }
}
