using GraduateProject.Common.DTOs.Lookups;
using GraduateProject.Common.Enums;
using GraduateProject.Common.Extentions;
using GraduateProject.Common.Models.SysModels;
using GraduateProject.Common.Services.Lookups;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateProject.CP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceTypeController : Controller
    {
        private readonly ILookupsCRUDService _lookupsCRUDService;
        public PlaceTypeController(ILookupsCRUDService lookupsCRUDService)
        {
            _lookupsCRUDService = lookupsCRUDService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<List<SysPlaceTypeDTO>>>> GetSysPlaceTypes()
        {
            try
            {
                var result = await _lookupsCRUDService.GetSysPlaceTypes();
                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<List<SysPlaceTypeDTO>>>> PlaceTypesList()
        {
            try
            {
                var result = await _lookupsCRUDService.PlaceTypesList();
                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        [HttpGet] 
        [Route("[action]/{id}")]
        public async Task<ActionResult<SysPlaceTypeDTO>> GetPlaceTypeById(int id)
        {
            try
            {
                var result = await _lookupsCRUDService.GetPlaceTypeById(id);
                if (result == null)
                    return Json(new ResponseResult(ResponseType.Error, result.ToString()));

                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }

        }

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdatePlaceType(SysPlaceTypeDTO placeTypeDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new ResponseResult(ResponseType.ModelNotValid, "Model State is Not Valid"));

                var result = await _lookupsCRUDService.UpdatePlaceType(placeTypeDTO);
                if (result == false)
                    return Json(new ResponseResult(ResponseType.Error, "There is an error with the result"));

                return Json(new ResponseResult(ResponseType.Success, result));

            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> AddPlaceType(SysPlaceTypeDTO sysPlaceType)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new ResponseResult(ResponseType.ModelNotValid, "Model State is Not Valid"));

                var result = await _lookupsCRUDService.AddPlaceType(sysPlaceType);
                if (result == null)
                    return Json(new ResponseResult(ResponseType.Error, "There is an error with the result"));

                return Json(new ResponseResult(ResponseType.Success, result));

            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }


        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult<SysPlaceTypeDTO>> DeletePlaceType(int id)
        {
            try
            {
                var result = await _lookupsCRUDService.DeletePlaceType(id);
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
