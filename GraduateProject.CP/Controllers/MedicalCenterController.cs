using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.MedicalCenter;
using GraduateProject.Common.Enums;
using GraduateProject.Common.Extentions;
using GraduateProject.Common.Models;
using GraduateProject.Common.Services.MedicalCenters;
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
    public class MedicalCenterController : Controller
    {
        private readonly IMedicalCentersService _medicalCentersService;
        public MedicalCenterController(IMedicalCentersService medicalCentersService)
        {
            _medicalCentersService = medicalCentersService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<MedicalCenterListDTO>>> GetAcitvatedMedicalCenters()
        {
            try
            {
                var result = await _medicalCentersService.GetAcitvatedMedicalCenters();
                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<MedicalCenterListDTO>>> GetUnActivatedMedicalCenters()
        {
            try
            {
                var result = await _medicalCentersService.GetUnActivatedMedicalCenters();
                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<MedicalCenterDTO>> GetMedicalCenterById(int id)
        {
            try
            {
                var result = await _medicalCentersService.GetMedicalCenterById(id);
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
        public async Task<IActionResult> UpdateMedicalCenter(MedicalCenterDTO medicalCenter)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new ResponseResult(ResponseType.ModelNotValid, "Model State is Not Valid"));

                var result = await _medicalCentersService.UpdateMedicalCenter(medicalCenter);
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
        public async Task<ActionResult> AddMedicalCenter(MedicalCenterDTO medicalCenter)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new ResponseResult(ResponseType.ModelNotValid, "Model State is Not Valid"));

                var result = await _medicalCentersService.AddMedicalCenter(medicalCenter);
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
        public async Task<ActionResult<MedicalCenterDTO>> DeleteMedicalCenter(int id)
        {
            try
            {
                var result = await _medicalCentersService.DeleteMedicalCenter(id);
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
