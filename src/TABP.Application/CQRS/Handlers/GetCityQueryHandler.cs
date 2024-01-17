using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers
{
    public class GetCityQueryHandler : IRequestHandler<GetCityQuery, Result<City>>
    {
        private readonly ICityRepository _cityRepository;
        public GetCityQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<Result<City>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetCityAsync(request.CityId);
            if (city != null)
            {
                return Result<City>.Success(city);
            }
            else
            {
                return Result<City>.Failure("No City was FOUND!");
            }
        }
    }
}
