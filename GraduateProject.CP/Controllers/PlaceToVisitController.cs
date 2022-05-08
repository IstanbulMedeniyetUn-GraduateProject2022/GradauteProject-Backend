using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.PlaceToVisit;
using GraduateProject.Common.Enums;
using GraduateProject.Common.Extentions;
using GraduateProject.Common.Models;
using GraduateProject.Common.Services.PlacesToVisit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateProject.CP.Controllers
{
    [Authorize(Roles = "Admin")]
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
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<PlaceToVisitListDTO>>> GetUnActivatedPlaces()
        {
            try
            {
                var result = await _placeToVisitsService.GetUnActivatedPlaces();
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

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdatePlace(PlaceToVisitDTO place)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new ResponseResult(ResponseType.ModelNotValid, "Model State is Not Valid"));

                var result = await _placeToVisitsService.UpdatePlace(place);
                if (result == false)
                    return Json(new ResponseResult(ResponseType.Error, "The result is null!!"));

                return Json(new ResponseResult(ResponseType.Success, result));

            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> AddPlace(PlaceToVisitDTO place)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new ResponseResult(ResponseType.ModelNotValid, "Model State is Not Valid"));

                var result = await _placeToVisitsService.AddPlace(place);
                if (result == false)
                    return Json(new ResponseResult(ResponseType.Error, "The result is null!!"));

                return Json(new ResponseResult(ResponseType.Success, result));

            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }


        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult<PlaceToVisitDTO>> DeletePlace(int id)
        {
            try
            {

                var result = await _placeToVisitsService.DeletePlace(id);
                if (result == false)
                    return Json(new ResponseResult(ResponseType.Error, "There is an error with the result"));

                return Json(new ResponseResult(ResponseType.Success, result));

            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }

        }
    }
}
