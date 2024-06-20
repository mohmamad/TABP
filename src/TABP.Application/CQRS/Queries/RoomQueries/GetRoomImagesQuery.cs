using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.RoomQueries
{
    public class GetRoomImagesQuery : IRequest<Result<List<RoomImage>>>
    {
        public Guid RoomId { get; set; }
    }
}
