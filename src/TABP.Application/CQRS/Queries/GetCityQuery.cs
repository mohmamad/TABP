using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;
using TABP.Infrastructure.Repositories;

namespace TABP.Application.CQRS.Queries
{
    public class GetCityQuery : IRequest<Result<City>>
    {
        public Guid CityId { get; set; }
    }
}
