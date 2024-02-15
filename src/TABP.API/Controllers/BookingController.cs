using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.API.DTOs.BookingDtos;
using TABP.Application.CQRS.Commands.BookingCommands;
using TABP.Application.CQRS.Queries.BookingQueries;

namespace TABP.API.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class BookingController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BookingController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost("{userId}")]
        public async Task<ActionResult<PaymentDto>> Book(AddBookingDto addBookingDto, Guid userId)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type.EndsWith("nameidentifier"));
            var userIdFromToken = new Guid();
            if (userIdClaim != null)
            {
                userIdFromToken = Guid.Parse(userIdClaim.Value);
            }
            else
            {
                return Unauthorized();
            }
            if(userIdFromToken == userId)
            {
               var result = await _mediator.Send(
                    new CheckBookingCommand
                    {
                        UserId = userId,
                        RoomId = addBookingDto.RoomId,
                        StartDate = addBookingDto.StartDate,
                        EndDate = addBookingDto.EndDate,
                        NumberOfResidents = addBookingDto.NumberOfResidents
                    });
                if (result.IsSuccess)
                {
                    var dtoToReturn = new PaymentDto
                    {
                        StartDate = addBookingDto.StartDate,
                        EndDate = addBookingDto.EndDate,
                        Price = result.Data,
                        PaymentURL = $"/api/booking/payment?userId={userId}&roomId={addBookingDto.RoomId}&startDate={addBookingDto.StartDate}&endDate={addBookingDto.EndDate}",
                        RoomURL = $"/api/room?roomId={addBookingDto.RoomId}"
                    };
                    return Ok(dtoToReturn);
                }
                else
                {
                    return BadRequest(result.ErrorMessage);
                }
                
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpPost("payment")]
        public async Task<ActionResult<PaymentDto>> AddPayment
            (
            AddPaymentDto addPaymentDto,
            [FromQuery] Guid userId,
            [FromQuery] Guid roomId,
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate
            )
        {
            
            var result = await _mediator.Send(
                    new AddBookingCommand
                    {
                        UserId = userId,
                        RoomId = roomId,
                        StartDate = startDate,
                        EndDate = endDate
                    });
            if (result.IsSuccess)
            {
                var dtoToReturn = _mapper.Map<BookingDto>(result.Data);
                return Ok(dtoToReturn);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpGet]
        public async Task<ActionResult<BookingDto>> GetBooking
            (
                [FromQuery] Guid? bookingId,
                [FromQuery] Guid? userId,
                [FromQuery] Guid? roomId,
                [FromQuery] DateTime? startDate,
                [FromQuery] DateTime? endDate,
                [FromQuery] int pageSize = 30,
                [FromQuery] int page = 1
            )
        {
            var result = await _mediator.Send
                (
                new GetBookingQuery
                {
                    BookingId = bookingId,
                    UserId = userId,
                    RoomId = roomId,
                    StartDate = startDate,
                    EndDate = endDate,
                    PageSize = pageSize,
                    Page = page
                }
                );
            if (result.IsSuccess)
            {
                var dtoToReturn = _mapper.Map<IEnumerable<BookingDto>>(result.Data);
                return Ok(dtoToReturn);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
            
        }

    }
}
