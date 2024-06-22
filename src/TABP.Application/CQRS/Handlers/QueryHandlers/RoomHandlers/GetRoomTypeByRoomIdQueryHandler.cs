using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.RoomQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.RoomQueryHandlers
{
    public class GetRoomTypeByRoomIdQueryHandler : IRequestHandler<GetRoomTypeByRoomIdQuery, Result<RoomType>>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomTypeByRoomIdQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<Result<RoomType>> Handle(GetRoomTypeByRoomIdQuery request, CancellationToken cancellationToken)
        {
            var roomType = await _roomRepository.GetRoomTypeByRoomIdAsync(request.RoomId);
            if (roomType == null) return Result<RoomType>.Failure("Room ID Not Found.");
            return Result<RoomType>.Success(roomType);
        }
    }
}
