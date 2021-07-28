using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.Models.Request;
using YuHan.CabsBooking.ApplicationCore.ServiceInterfaces;

namespace YuHan.CabsBooking.MVC.Controllers
{
    public class BookingHistoryController : Controller
    {
        private readonly IBookingHistoryService _bookingHistoryService;

        public BookingHistoryController(IBookingHistoryService bookingHistoryService)
        {
            _bookingHistoryService = bookingHistoryService;
        }

        public async Task<IActionResult> Index()
        {
            var bookingHistories = await _bookingHistoryService.ListAll();
            if (!bookingHistories.Any())
            {
                return View();
            }
            return View(bookingHistories);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookingHistoryAddRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _bookingHistoryService.Add(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(BookingHistoryUpdateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _bookingHistoryService.Update(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BookingHistoryUpdateRequestModel model)
        {

            int id = model.Id;
            await _bookingHistoryService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
