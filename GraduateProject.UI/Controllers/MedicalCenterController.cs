using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.MedicalCenter;
using GraduateProject.Common.Enums;
using GraduateProject.Common.Extentions;
using GraduateProject.Common.Models;
using GraduateProject.Common.Services.MedicalCenters;
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
        [Route("[action]/{id}")]
        public async Task<ActionResult<MedicalCenterDTO>> GetMedicalCenterById(int id)
        {
            try
            {
                var result = await _medicalCentersService.GetMedicalCenterById(id);
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
