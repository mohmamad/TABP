using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.HotelQueries
{
    public class GetHotelImageByHotelIdQuery : IRequest<Result<HotelImage>>
    {
        public Guid HotelId;
    }
}
