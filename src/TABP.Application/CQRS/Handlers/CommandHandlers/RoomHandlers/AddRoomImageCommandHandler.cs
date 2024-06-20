using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.RoomCommands;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.RoomHandlers
{
    public class AddRoomImageCommandHandler : IRequestHandler<AddRoomImageCommand, Result<List<RoomImage>>>
    {
        private IRoomRepository _roomRepository;
        public AddRoomImageCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<Result<List<RoomImage>>> Handle(AddRoomImageCommand request, CancellationToken cancellationToken)
        {
            var result = await _roomRepository.AddRoomImageAsync(request.RoomId, request.RoomImageBaths);
            if(result == null)
            {
                return Result<List<RoomImage>>.Failure("Room Does Not Exist.");
            }
            return Result<List<RoomImage>>.Success(result);
        }
    }
}
