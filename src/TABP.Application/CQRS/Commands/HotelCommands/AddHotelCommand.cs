using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands.HotelCommands
{
    public class AddHotelCommand : IRequest<Result<Hotel>>
    {
        public string HotelName { get; set; }
        public string HotelDescription { get; set; }
        public double Rating { get; set; }
        public string Amenities { get; set; }
        public Guid HotelTypeId { get; set; }
    }
}
