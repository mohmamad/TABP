using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands.FeaturedDealsCommands
{
    public class AddFeaturedDealCommand : IRequest<Result<FeaturedDeal>>
    {
        public Guid RoomId { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
