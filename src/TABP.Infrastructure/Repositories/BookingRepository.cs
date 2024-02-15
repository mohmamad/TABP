using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TABPDbContext _dbContext;
        public BookingRepository(TABPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Booking> AddBooking(Booking booking)
        {
            await _dbContext.AddAsync(booking);
            await _dbContext.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> GetLatestEndDate(Guid roomId, DateTime date)
        {
            return await _dbContext.Bookings.FirstOrDefaultAsync(b => b.RoomId == roomId && b.EndDate > date);
        }

        public async Task<IEnumerable<Booking>> GetBookingAsync
            (
                 Guid? bookingId,
                 Guid? userId,
                 Guid? roomId,
                 DateTime? startDate,
                 DateTime? endDate,
                 int pageSize,
                 int page
            )
        {
            IQueryable<Booking> bookingQuery = _dbContext.Bookings;
            if (bookingId != null )
            {
                bookingQuery = bookingQuery.Where(b => b.BookingId == bookingId);
            }
            if (userId != null)
            {
                bookingQuery = bookingQuery.Where(b => b.UserId == userId);
            }
            if (roomId != null)
            {
                bookingQuery = bookingQuery.Where(b => b.RoomId == roomId);
            }
            if (startDate != null)
            {
                bookingQuery = bookingQuery.Where(b => b.StartDate == startDate);
            }
            if (endDate != null)
            {
                bookingQuery = bookingQuery.Where(b => b.EndDate == endDate);
            }
            return await bookingQuery.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(); ;
        }

    }
}
