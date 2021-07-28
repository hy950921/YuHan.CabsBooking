using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.Models.Request;
using YuHan.CabsBooking.ApplicationCore.RepositoryInterfaces;
using YuHan.CabsBooking.ApplicationCore.ServiceInterfaces;

namespace YuHan.CabsBooking.MVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingService.ListAll();
            if (!bookings.Any())
            {
                return View();
            }
            return View(bookings);
        }

        public async Task<IActionResult> Details(int id)
        {
            var bookings = await _bookingService.GetBookingsByCabId(id);
            if (!bookings.Any())
            {
                return View();
            }
            return View(bookings);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookingAddRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _bookingService.Add(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(BookingUpdateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _bookingService.Update(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BookingUpdateRequestModel model)
        {

            int id = model.Id;
            await _bookingService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
