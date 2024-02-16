using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.LocationQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.LocationHandlers
{
    public class GetMostVisitedCitiesQueryHandler : IRequestHandler<GetMostVisitedCitiesQuery, Result<IEnumerable<City>>>
    {
        private readonly ICityRepository _cityRepository;
        public GetMostVisitedCitiesQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<Result<IEnumerable<City>>> Handle(GetMostVisitedCitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await _cityRepository.GetMostVistedCitiesAsync();
            if (cities != null)
            {
                return Result<IEnumerable<City>>.Success(cities);
            }
            else
            {
                return Result<IEnumerable<City>>.Failure("City Not Found.");
            }
        }
    }
}
