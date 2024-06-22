using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.HotelQueries
{
    public class GetHotelTypeByHotelIdQuery : IRequest<Result<HotelType>>
    {
        public Guid hotelId { get; set; }
    }
}
