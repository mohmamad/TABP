using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.AmenityQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.AmenityHandlers
{
    public class GetAmenityByHotelIdQueryHandler : IRequestHandler<GetAmenityByHotelIdQuery, Result<IEnumerable<Amenity>>>
    {
        private readonly IAmenityRepository _amenityRepository;
        public GetAmenityByHotelIdQueryHandler(IAmenityRepository amenityRepository)
        {
            _amenityRepository = amenityRepository;
        }
        public async Task<Result<IEnumerable<Amenity>>> Handle(GetAmenityByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var amenities = await _amenityRepository.GetAmenityByHotelIdAsync(request.HotelId);

            if(amenities != null)
            {
                return Result<IEnumerable<Amenity>>.Success(amenities);
            }
            else
            {
                return Result<IEnumerable<Amenity>>.Failure("Amenities not found.");
            }
        }


    }
}
