using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.BookingCommands;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.BookingHandler
{
    public class AddBookingCommandHandler : IRequestHandler<AddBookingCommand, Result<Booking>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IFeaturedDealsRepository _featuredDealsRepository;
        public AddBookingCommandHandler(IBookingRepository bookingRepository, IRoomRepository roomRepository, IFeaturedDealsRepository featuredDealsRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;   
            _featuredDealsRepository = featuredDealsRepository;
        }
        public async Task<Result<Booking>> Handle(AddBookingCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByIdAsync(request.RoomId);
            var featuredDeal = await _featuredDealsRepository.GetFeaturedDealByRoomIdAsync(request.RoomId);
            var price = room.Price;
            if(featuredDeal != null)
            {
                price = price * featuredDeal.Discount;
            }

            if(request.priceToPay >= price)
            {
                var booking = await _bookingRepository.AddBooking
                (
                new Booking
                {
                    UserId = request.UserId,
                    RoomId = request.RoomId,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                }
                );

                return Result<Booking>.Success(booking);
            }
            else
            {
                return Result<Booking>.Failure("No enough money.");
            }
        }


    }
}
