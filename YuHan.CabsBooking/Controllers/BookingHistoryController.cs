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
    public class BookingHistoryController : ControllerBase
    {
        private readonly IBookingHistoryService  _bookingHistoryService;

        public BookingHistoryController(IBookingHistoryService bookingHistoryService)
        {
            _bookingHistoryService = bookingHistoryService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ListAllBookingHistories()
        {
            var bookingHistories = await _bookingHistoryService.ListAll();

            if (!bookingHistories.Any())
            {
                return NotFound("404 NOT FOUND BOOKING");
            }
            return Ok(bookingHistories);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBookingHistory([FromBody] BookingHistoryAddRequestModel model)
        {
            var res = await _bookingHistoryService.Add(model);

            return Ok(res);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateBookingHistory([FromBody] BookingHistoryUpdateRequestModel model)
        {
            var res = await _bookingHistoryService.Update(model);

            return Ok(res);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBookingHistory(int id)
        {
            var res = await _bookingHistoryService.Delete(id);

            return Ok(res);
        }
    }
}
