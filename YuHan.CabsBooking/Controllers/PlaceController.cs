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
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ListAllPlaces()
        {
            var places = await _placeService.ListAll();
            if (!places.Any())
            {
                return NotFound("404 NOT FOUND PLACES");
            }
            return Ok(places);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddPlace([FromBody] PlaceAddRequestModel model)
        {
            var res = await _placeService.Add(model);

            return Ok(res);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdatePlace([FromBody] PlaceUpdateRequestModel model)
        {
            var res = await _placeService.Update(model);

            return Ok(res);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePlaceType(int id)
        {
            var res = await _placeService.Delete(id);

            return Ok(res);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPlaceById(int id)
        {
            var res = await _placeService.GetById(id);

            if (res == null)
            {
                return NotFound("404 NOT FOUND PLACE");
            }

            return Ok(res);
        }
    }
}
