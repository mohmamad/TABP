using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.FeaturedDealsCommands;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.FeaturedDealsHandlers
{
    public class AddFeaturedDealCommandHandler : IRequestHandler<AddFeaturedDealCommand, Result<FeaturedDeal>>
    {
        private readonly IFeaturedDealsRepository _featuredDealsRepository;
        private readonly IRoomRepository _roomRepository;
        public AddFeaturedDealCommandHandler(IFeaturedDealsRepository featuredDealsRepository, IRoomRepository roomRepository)
        {
            _featuredDealsRepository = featuredDealsRepository;
            _roomRepository = roomRepository;   
        }
        public async Task<Result<FeaturedDeal>> Handle(AddFeaturedDealCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByIdAsync(request.RoomId);
            if(room != null)
            {
                var featuredDeal = new FeaturedDeal
                {
                    RoomId = request.RoomId,
                    Description = request.Description,
                    Discount = request.Discount,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                };
                var result = await _featuredDealsRepository.AddFeaturedDealAsync(featuredDeal);
                return Result<FeaturedDeal>.Success(result);
            }
            else
            {
                return Result<FeaturedDeal>.Failure("The Room does not exist.");
            }
        }
    }
}
