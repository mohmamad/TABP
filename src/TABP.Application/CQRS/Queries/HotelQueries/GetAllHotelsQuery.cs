using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.HotelQueries
{
    public class GetAllHotelsQuery : IRequest<Result<List<Hotel>>>
    {
        public string? Name { get; set; }
    }
}
