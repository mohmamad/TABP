using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers
{
    public class GetRoomTypeByIdQueryHandler : IRequestHandler<GetRoomTypeByIdQuery, Result<RoomType>>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomTypeByIdQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<Result<RoomType>> Handle(GetRoomTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var roomType = await _roomRepository.GetRoomTypeByRoomIdAsync(request.RoomTypeId);
            return Result<RoomType>.Success(roomType);
        }
    }
}
