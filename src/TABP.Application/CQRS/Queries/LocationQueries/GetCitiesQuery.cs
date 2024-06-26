using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.LocationQueries
{
    public class GetCitiesQuery : IRequest<Result<List<City>>>
    {
    }
}
