using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers
{
    public class AddRoomTypeCommandHandler : IRequestHandler<AddRoomTypeCommand, Result<RoomType>>
    {
        private readonly IRoomRepository _roomRepository;
        public AddRoomTypeCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Result<RoomType>> Handle(AddRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var roomType = await _roomRepository.AddRoomTypeAsync(new RoomType
            {
                Type = request.Type
            });

            return Result<RoomType>.Success(roomType);
        }

    }
}
