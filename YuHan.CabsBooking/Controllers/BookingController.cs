using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.Models.Request;
using YuHan.CabsBooking.ApplicationCore.ServiceInterfaces;

namespace YuHan.CabsBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ListAllBookings()
        {
            var bookings = await _bookingService.ListAll();

            if (!bookings.Any())
            {
                return NotFound("404 NOT FOUND BOOKING");
            }
            return Ok(bookings);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBooking([FromBody] BookingAddRequestModel model)
        {
            var res = await _bookingService.Add(model);

            return Ok(res);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateBooking([FromBody] BookingUpdateRequestModel model)
        {
            var res = await _bookingService.Update(model);

            return Ok(res);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var res = await _bookingService.Delete(id);

            return Ok(res);
        }
    }
}
