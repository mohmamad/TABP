using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.BookingCommands;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.BookingHandler
{
    public class CheckBookingCommandHandler : IRequestHandler<CheckBookingCommand, Result<double>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IFeaturedDealsRepository _featuredDealsRepository;
        public CheckBookingCommandHandler(IBookingRepository bookingRepository, IRoomRepository roomRepository, IFeaturedDealsRepository featuredDealsRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;   
            _featuredDealsRepository = featuredDealsRepository;
        }
        public async Task<Result<double>> Handle(CheckBookingCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByIdAsync(request.RoomId);

            if (room == null)
            {
                return Result<double>.Failure("Room Not Found");
            }

            var date = await _bookingRepository.GetLatestEndDate(request.RoomId, request.StartDate);

            if (date != null)
            {
                return Result<double>.Failure("The room in not available.");
            }

            if(room.Capacity <= request.NumberOfResidents)
            {
                var price = room.Price;
                var featuredDeal = await _featuredDealsRepository.GetFeaturedDealByRoomIdAsync(room.RoomId);
                if (featuredDeal != null)
                {
                    price = price * featuredDeal.Discount;
                }
                return Result<double>.Success(price);
            }
            else
            {
                return Result<double>.Failure("No enough capacity in the room.");
            }
            
        }
    }
}
