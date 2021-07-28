using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.Models.Request;
using YuHan.CabsBooking.ApplicationCore.RepositoryInterfaces;
using YuHan.CabsBooking.ApplicationCore.ServiceInterfaces;
using YuHan.CabsBooking.MVC.Models;

namespace YuHan.CabsBooking.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICabTypeService _cabTypeService;

        public HomeController(ILogger<HomeController> logger, ICabTypeService cabTypeService)
        {
            _logger = logger;
            _cabTypeService = cabTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var cabTypes = await _cabTypeService.ListAll();
            if (!cabTypes.Any())
            {
                return View();
            }
            return View(cabTypes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CabTypeAddRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _cabTypeService.Add(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(CabTypeUpdateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _cabTypeService.Update(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CabTypeUpdateRequestModel model)
        {

            int id = model.CabTypeId;
            await _cabTypeService.Delete(id);

            return RedirectToAction("Index");
        }













        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
