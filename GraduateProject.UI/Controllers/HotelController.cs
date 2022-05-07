using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.Hotel;
using GraduateProject.Common.Enums;
using GraduateProject.Common.Extentions;
using GraduateProject.Common.Models;
using GraduateProject.Common.Services.Hotels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateProject.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : Controller
    {
        private readonly IHotelsService _hotelsService;
        public HotelController(IHotelsService hotelsService)
        {
            _hotelsService = hotelsService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<HotelListDTO>>> GetAcitvatedHotels()
        {
            try
            {
                var result = await _hotelsService.GetAcitvatedHotels();
                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotelById(int id)
        {
            try
            {
                var result = await _hotelsService.GetHotelById(id);
                if (result == null)
                    return Json(new ResponseResult(ResponseType.Error, result));

                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }

        }

    }
}
