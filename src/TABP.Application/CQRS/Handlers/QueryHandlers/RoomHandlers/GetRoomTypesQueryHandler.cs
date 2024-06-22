using MediatR;
using Microsoft.IdentityModel.Tokens;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.RoomQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.RoomHandlers
{
    public class GetRoomTypesQueryHandler : IRequestHandler<GetRoomTypesQuery, Result<List<RoomType>>>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomTypesQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<Result<List<RoomType>>> Handle(GetRoomTypesQuery request, CancellationToken cancellationToken)
        {
            var roomTypes = await _roomRepository.GetRoomTypes();
            if (roomTypes.IsNullOrEmpty()) { return Result<List<RoomType>>.Failure("Room Types not found."); }
            return Result<List<RoomType>>.Success(roomTypes);
        }
    }
}
