using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.PlaceToVisit;
using GraduateProject.Common.Enums;
using GraduateProject.Common.Extentions;
using GraduateProject.Common.Models;
using GraduateProject.Common.Services.PlacesToVisit;
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
    public class PlaceToVisitController : Controller
    {
        private readonly IPlacesToVisitService _placeToVisitsService;
        public PlaceToVisitController(IPlacesToVisitService placeToVisitsService)
        {
            _placeToVisitsService = placeToVisitsService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<PlaceToVisitListDTO>>> GetAcitvatedPlaces()
        {
            try
            {
                var result = await _placeToVisitsService.GetAcitvatedPlaces();
                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<PlaceToVisitDTO>> GetPlaceById(int id)
        {
            try
            {
                var result = await _placeToVisitsService.GetPlaceById(id);
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
