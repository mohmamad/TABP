﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.API.DTOs.BookingDtos;
using TABP.API.DTOs.RoomDtos;
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

        [HttpPost("user/{userId}/cart")]
        public async Task<ActionResult<IEnumerable<BookingDto>>> bookFromCart(Guid userId)
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
            if (userIdFromToken == userId)
            {
                var result = await _mediator.Send(new AddBookingFromCartCommand
                {
                    UserId = userId,
                });

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
            else
            {
                return Unauthorized();
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

                string baseUrl = Request.Scheme + "://" + Request.Host + Request.Path;
                string prevPageUrl = page > 1 ? $"{baseUrl}?page={page - 1}&pageSize={pageSize}" : null;
                string nextPageUrl = $"{baseUrl}?page={page + 1}&pageSize={pageSize}";

                var paginationInfo = new
                {
                    PrevPage = prevPageUrl,
                    NextPage = nextPageUrl,
                    count = dtoToReturn.Count()
                };

                var responseObj = new
                {
                    Pagination = paginationInfo,
                    Bookings = dtoToReturn
                };

                return Ok(responseObj);

            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }

        }

    }
}
