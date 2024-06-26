using MediatR;
using Microsoft.IdentityModel.Tokens;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.LocationQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.LocationHandlers
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, Result<List<City>>>
    {
        private readonly ICityRepository _cityRepository;
        public GetCitiesQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<Result<List<City>>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await _cityRepository.GetAllCitiesAsync();
            if (cities.IsNullOrEmpty()) return Result<List<City>>.Failure("Cities Not Found.");

            return Result<List<City>>.Success(cities.ToList());
        }
    }
}
