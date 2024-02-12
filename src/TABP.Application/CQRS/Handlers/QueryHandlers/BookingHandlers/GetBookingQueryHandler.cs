using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.BookingQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.BookingHandlers
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, Result<IEnumerable<Booking>>>
    {
        private readonly IBookingRepository _bookingRepository;
        public GetBookingQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<Result<IEnumerable<Booking>>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetBookingAsync
                (
                request.bookingId,
                request.userId,
                request.roomId,
                request.startDate,
                request.endDate,
                request.pageSize,
                request.page
                );
            if( booking != null )
            {
                return Result<IEnumerable<Booking>>.Success(booking);
            }
            else
            {
                return Result<IEnumerable<Booking>>.Failure("booking not found.");
            }
        }
    }
}
