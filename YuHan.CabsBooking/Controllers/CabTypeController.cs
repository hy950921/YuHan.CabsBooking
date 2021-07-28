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
    public class CabTypeController : ControllerBase
    {
        private readonly ICabTypeService _cabTypeService;

        public CabTypeController(ICabTypeService cabTypeService)
        {
            _cabTypeService = cabTypeService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ListAllCabTypes()
        {
            var res = await _cabTypeService.ListAll();
            if (!res.Any())
            {
                return NotFound("404 NOT FOUND CabTypes");
            }
            return Ok(res);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCabType([FromBody] CabTypeAddRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _cabTypeService.Add(model);

                return Ok(res);
            }
            return BadRequest("ERROR!");
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateCabType([FromBody] CabTypeUpdateRequestModel model)
        {
            var res = await _cabTypeService.Update(model);

            return Ok(res);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCabType(int id)
        {
            var res = await _cabTypeService.Delete(id);

            return Ok(res);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCabTypeById(int id)
        {
            var res = await _cabTypeService.GetById(id);

            if(res == null)
            {
                return NotFound("404 NOT FOUND CABTYPE");
            }

            return Ok(res);
        }
    }
}
