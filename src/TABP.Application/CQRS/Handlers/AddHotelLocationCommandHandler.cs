using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers
{
    public class AddHotelLocationCommandHandler : IRequestHandler<AddHotelLocationCommand, Result<Location>>
    {
        private readonly ILocationRepository _repository;
        public AddHotelLocationCommandHandler(ILocationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<Location>> Handle(AddHotelLocationCommand request, CancellationToken cancellationToken)
        {
            var location = new Location{
                CountryName = request.CountryName,
                StreetName = request.StreetName,
                PostalCode = request.PostalCode
            };
            var city = new City
            {
                CityName = request.CityName,
                CityDescription = request.CityDescription,
                CityImagePath = request.ImagePath
            };
            await _repository.AddHotelLocationAsync(location, city);

            return Result<Location>.Success(location);
        }
    }
}
