using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.Models.Request;
using YuHan.CabsBooking.ApplicationCore.ServiceInterfaces;

namespace YuHan.CabsBooking.MVC.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var places = await _placeService.ListAll();

            if (!places.Any())
            {
                throw new Exception("No service places");
            }
            return View(places);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PlaceAddRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _placeService.Add(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(PlaceUpdateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _placeService.Update(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PlaceUpdateRequestModel model)
        {
            
            int id = model.PlaceId;
            await _placeService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
