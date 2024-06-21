using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands.BookingCommands
{
    public class AddBookingFromCartCommand : IRequest<Result<IEnumerable<Booking>>>
    {
        public string CardDetailsToken { get; set; }
        public string IdempotencyKey { get; set; }
        public Guid UserId { get; set; }
    }
}
