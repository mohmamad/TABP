using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.BookingQueries
{
    public class GetBookingQuery : IRequest<Result<IEnumerable<Booking>>>
    {
        public Guid? BookingId;
        public Guid? UserId;
        public Guid? RoomId;
        public DateTime? StartDate;
        public DateTime? EndDate;
        public int PageSize;
        public int Page;
    }
}
