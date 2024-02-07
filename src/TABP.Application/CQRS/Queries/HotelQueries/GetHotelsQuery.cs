using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.HotelQueries
{
    public class GetHotelsQuery : IRequest<Result<IEnumerable<Hotel>>>
    {
        public Guid? HotelId;
        public string? HotelName;
        public string? HotelDescription;
        public double? Rating;
        public string? Amenities;
        public Guid? HotelTypeId;
        public int PageSize = 30;
        public int Page = 1;
    }
}
