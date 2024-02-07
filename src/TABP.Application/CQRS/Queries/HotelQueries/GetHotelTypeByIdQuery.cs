using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.HotelQueries
{
    public class GetHotelTypeByIdQuery : IRequest<Result<HotelType>>
    {
        public Guid hotelTypeId { get; set; }
    }
}
