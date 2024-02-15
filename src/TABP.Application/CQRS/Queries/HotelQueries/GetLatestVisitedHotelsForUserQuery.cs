using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.HotelQueries
{
    public class GetLatestVisitedHotelsForUserQuery : IRequest<Result<IEnumerable<Hotel>>>
    {
        public Guid UserId { get; set; }
    }
}
