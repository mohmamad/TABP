using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;
using TABP.Infrastructure.Repositories;

namespace TABP.Application.CQRS.Queries.LocationQueries
{
    public class GetCityQuery : IRequest<Result<City>>
    {
        public Guid CityId { get; set; }
    }
}
