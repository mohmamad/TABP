using MediatR;
using Microsoft.IdentityModel.Tokens;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.BookingCommands;
using TABP.Application.CQRS.Queries.CartItemQueries;
using TABP.Domain.Entities;
using TABP.Domain.Enums;
using TABP.Domain.Interfaces;
using TABP.Infrastructure.Repositories;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.BookingHandler
{
    public class AddBookingFromCartCommandHandler : IRequestHandler<AddBookingFromCartCommand, Result<IEnumerable<Booking>>>
    {
        private readonly IBookingRepository _bookingRepository; 
        private readonly IMediator _mediator;
        private readonly IRoomRepository _roomRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IInvoiceEmailService _invoiceEmailService;
        private readonly IUserRepository _userRepository;
        private readonly IHotelRepository _hotelRepository;

        public AddBookingFromCartCommandHandler(
            IBookingRepository bookingRepository, 
            IMediator mediator, 
            IRoomRepository roomRepository,
            ICartItemRepository cartItemRepository,
            IInvoiceEmailService invoiceEmailService,
            IUserRepository userRepository,
            IHotelRepository hotelRepository)
        {
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
            _mediator = mediator;   
            _cartItemRepository = cartItemRepository;
            _invoiceEmailService = invoiceEmailService;
            _userRepository = userRepository;  
            _hotelRepository = hotelRepository;
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

                
                List<int> rooms = new List<int>();
                List<double> pricePerDay = new List<double>();
                List<string> hotelName = new List<string>();
                List<int> numberOfDays = new List<int>();

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
                    var booking = await _bookingRepository.AddBooking(new Booking
                    {
                        UserId = cartItem.UserId,
                        RoomId = cartItem.RoomId,
                        StartDate = cartItem.StartDate,
                        EndDate = cartItem.EndDate,
                    });
                    bookings.Add(booking);
                    cartItem.RoomStatus = RoomStatus.Booked;

                    var hotel = await _hotelRepository.GetHotelById(room.HotelId);


                    hotelName.Add(hotel.HotelName);
                    rooms.Add(room.RoomNumber);
                    pricePerDay.Add(room.Price);

                    numberOfDays.Add((cartItem.EndDate - cartItem.StartDate).Days);

                    var roomP = await _roomRepository.GetRoomByIdAsync(cartItem.RoomId);
                   
                    await _cartItemRepository.SaveChangesAsync();
                }

                var user = await _userRepository.GetUserByIdAsync(cartItems.Data.ToList()[0].UserId);

                string userName = user.FirstName + " " + user.LastName;
                string userEmail = user.Email;

                await _invoiceEmailService.prepareEmailMessage(userName, userEmail,pricePerDay, rooms, hotelName, numberOfDays);

                return Result<IEnumerable<Booking>>.Success(bookings);
            }
            else
            {
                return Result<IEnumerable<Booking>>.Failure("The Cart is empty.");
            }

        }
    }
}
