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
            var transaction = _dbContext.Database.BeginTransaction();   
            await _dbContext.AddAsync(booking);
            await _dbContext.SaveChangesAsync();
            transaction.Commit();
            return booking;
        }

        public async Task<bool> IsRoomAvailable(Guid roomId, DateTime startDate, DateTime endDate)
        {
            var overlappingBookings = await _dbContext.Bookings
                .Where(b => b.RoomId == roomId &&
                            ((b.StartDate >= startDate && b.StartDate <= endDate) ||
                             (b.EndDate >= startDate && b.EndDate <= endDate)))
                .ToListAsync();

            
            return !overlappingBookings.Any();
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
