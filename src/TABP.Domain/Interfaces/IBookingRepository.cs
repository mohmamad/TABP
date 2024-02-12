using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces
{
    public interface IBookingRepository
    {
        public Task<Booking> AddBooking(Booking booking);
        public Task<Booking> GetLatestEndDate(Guid roomId, DateTime date);
        public Task<IEnumerable<Booking>> GetBookingAsync
            (
                 Guid? bookingId,
                 Guid? userId,
                 Guid? roomId,
                 DateTime? startDate,
                 DateTime? endDate,
                 int pageSize,
                 int page
            );
    }
}
