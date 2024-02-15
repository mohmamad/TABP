using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.RoomQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.RoomHandlers
{
    public class GetRoomsWithFeatureddealsByHotelIdQueryHandler : IRequestHandler<GetRoomsWithFeatureddealsByHotelIdQuery, Result<IEnumerable<Room>>>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomsWithFeatureddealsByHotelIdQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<Result<IEnumerable<Room>>> Handle(GetRoomsWithFeatureddealsByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetRoomsWithFeaturedDealsByHotelIdAsync(request.HotelId);
            if (rooms != null)
            {
                return Result<IEnumerable<Room>>.Success(rooms);
            }
            else
            {
                return Result<IEnumerable<Room>>.Failure("Room Not Found.");
            }
        }
    }
}
