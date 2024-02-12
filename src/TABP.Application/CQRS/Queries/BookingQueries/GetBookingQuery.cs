using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.BookingQueries
{
    public class GetBookingQuery : IRequest<Result<IEnumerable<Booking>>>
    {
        public Guid? bookingId;
        public Guid? userId;
        public Guid? roomId;
        public DateTime? startDate;
        public DateTime? endDate;
        public int pageSize;
        public int page;
    }
}
