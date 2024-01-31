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
                StreetName = request.StreetName,
                PostalCode = request.PostalCode,
                HotelId = request.HotelId
            };
            var city = new City
            {
                CityName = request.CityName,
                CountryName = request.CountryName,
                CityDescription = request.CityDescription,
                CityImagePath = request.ImagePath
            };
            try
            {
                await _repository.AddHotelLocationAsync(location, city);
            }catch (Exception ex)
            {
                return Result<Location>.Failure("the hotel you are trying to add the location for does not exist.");
            }
            

            return Result<Location>.Success(location);
        }
    }
}
