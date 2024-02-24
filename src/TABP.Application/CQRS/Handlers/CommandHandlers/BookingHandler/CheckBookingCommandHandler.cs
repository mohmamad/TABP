using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.BookingCommands;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.BookingHandler
{
    public class CheckBookingCommandHandler : IRequestHandler<CheckBookingCommand, Result<Dictionary<string, double>>>
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
        public async Task<Result<Dictionary<string, double>>> Handle(CheckBookingCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByIdAsync(request.RoomId);

            if (room == null)
            {
                return Result<Dictionary<string, double>>.Failure("Room Not Found");
            }

            var isRoomAvailable = await _bookingRepository.IsRoomAvailable(request.RoomId, request.StartDate, request.EndDate);

            if (!isRoomAvailable)
            {
                return Result<Dictionary<string, double>>.Failure("The room in not available.");
            }

            if(room.Capacity <= request.NumberOfResidents)
            {
                Dictionary<string, double> hashMap = new Dictionary<string, double>();

                hashMap.Add("price", room.Price);
                hashMap.Add("discount", 0.0);

                var featuredDeal = await _featuredDealsRepository.GetFeaturedDealByRoomIdAsync(room.RoomId);
                if (featuredDeal != null)
                {
                    hashMap["discount"] = featuredDeal.Discount;
                }

                return Result<Dictionary<string, double>>.Success(hashMap);
            }
            else
            {
                return Result<Dictionary<string, double>>.Failure("No enough capacity in the room.");
            }
            
        }
    }
}
