using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.RoomQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.RoomQueryHandlers
{
    public class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, Result<IEnumerable<Room>>>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomsQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<Result<IEnumerable<Room>>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomsAsync
                (
                    request.RoomId,
                    request.HotelId,
                    request.RoomTypeId,
                    request.RoomNumber,
                    request.Price,
                    request.Capacity,
                    request.MaxPrice,
                    request.MinPrice,
                    request.PageSize,
                    request.Page
                );
            return Result<IEnumerable<Room>>.Success(room);
        }
    }
}
