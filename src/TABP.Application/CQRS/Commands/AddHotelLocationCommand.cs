using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Commands
{
    public class AddHotelLocationCommand : IRequest<Result<Location>>
    {
        public string CountryName { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string CityName { get; set; }
        public string CityDescription { get; set; }
        public string ImagePath { get; set; }
        public Guid HotelId { get; set; }
    }
}
