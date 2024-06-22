using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.RoomQueries
{
    public class GetRoomTypesQuery : IRequest<Result<List<RoomType>>>
    {
    }
}
