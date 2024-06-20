using MediatR;
using Microsoft.IdentityModel.Tokens;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.RoomQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.RoomHandlers
{
    public class GetRoomImagesQueryHandler : IRequestHandler<GetRoomImagesQuery, Result<List<RoomImage>>>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomImagesQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<Result<List<RoomImage>>> Handle(GetRoomImagesQuery request, CancellationToken cancellationToken)
        {
            var roomImages = await _roomRepository.GetRoomImagesAsync(request.RoomId);
            if (roomImages.IsNullOrEmpty())
            {
                return Result<List<RoomImage>>.Failure("Room Not Found.");
            }
            return Result<List<RoomImage>>.Success(roomImages);
        }
    }
}
