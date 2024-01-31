using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers
{
    public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, Result<Room>>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomByIdQueryHandler( IRoomRepository roomRepository )
        {
            _roomRepository = roomRepository;
        }
        public async Task<Result<Room>> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByIdAsync(request.RoomId);
            if (room != null)
            {
                return Result<Room>.Success( room );
            }
            else
            {
                return Result<Room>.Failure("Room not found");
            }
        }
    }
}
