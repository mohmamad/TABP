using MediatR;
using Microsoft.IdentityModel.Tokens;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.BookingCommands;
using TABP.Application.CQRS.Queries.CartItemQueries;
using TABP.Domain.Entities;
using TABP.Domain.Enums;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.BookingHandler
{
    public class AddBookingFromCartCommandHandler : IRequestHandler<AddBookingFromCartCommand, Result<IEnumerable<Booking>>>
    {
        private readonly IBookingRepository _bookingRepository; 
        private readonly IMediator _mediator;
        private readonly IRoomRepository _roomRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ITransactionService _transactionService;
        public AddBookingFromCartCommandHandler(
            IBookingRepository bookingRepository, 
            IMediator mediator, 
            IRoomRepository roomRepository,
            ICartItemRepository cartItemRepository)
        {
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
            _mediator = mediator;   
            _cartItemRepository = cartItemRepository;
        }
        public async Task<Result<IEnumerable<Booking>>> Handle(AddBookingFromCartCommand request, CancellationToken cancellationToken)
        {
            var cartItems = await _mediator.Send(new GetCartItemByUserIdQurey
            {
                UserId = request.UserId,
            });
            if (!cartItems.Data.IsNullOrEmpty())
            {

                List<Booking> bookings = new List<Booking>();

                
                foreach (var cartItem in cartItems.Data)
                {
                    var room = await _roomRepository.GetRoomByIdAsync(cartItem.RoomId);

                    if (room == null)
                    {
                        return Result<IEnumerable<Booking>>.Failure("Room Not Found");
                    }

                    var isRoomAvailable = await _bookingRepository.IsRoomAvailable(cartItem.RoomId, cartItem.StartDate, cartItem.EndDate);

                    if (!isRoomAvailable)
                    {
                        return Result<IEnumerable<Booking>>.Failure("The room in not available.");
                    }

                    if(cartItem.StartDate >= cartItem.EndDate || cartItem.StartDate < DateTime.UtcNow)
                    {
                        return Result<IEnumerable<Booking>>.Failure("Invalid Date.");
                    }

                    var booking = await _bookingRepository.AddBooking(new Booking
                    {
                        UserId = cartItem.UserId,
                        RoomId = cartItem.RoomId,
                        StartDate = cartItem.StartDate,
                        EndDate = cartItem.EndDate,
                    });
                    bookings.Add(booking);
                    cartItem.RoomStatus = RoomStatus.Booked;

                    var roomP = await _roomRepository.GetRoomByIdAsync(cartItem.RoomId);
                   
                    await _cartItemRepository.SaveChangesAsync();
                }
                //TODO get the price of the booked rooms to send the email to the user


                return Result<IEnumerable<Booking>>.Success(bookings);
            }
            else
            {
                return Result<IEnumerable<Booking>>.Failure("The Cart is empty.");
            }

        }
    }
}
