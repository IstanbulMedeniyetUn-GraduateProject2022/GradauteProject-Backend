using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.Doctor;
using GraduateProject.Common.Enums;
using GraduateProject.Common.Extentions;
using GraduateProject.Common.Models;
using GraduateProject.Common.Services.Doctors;
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
    public class DoctorController : Controller
    {
        private readonly IDoctorsService _doctorsService;
        public DoctorController(IDoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<DoctorListDTO>>> GetActivatedDoctors()
        {
            try
            {
                var result = await _doctorsService.GetActivatedDoctors();
                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<DoctorDTO>> GetDoctorById(int id)
        {
            try
            {
                var result = await _doctorsService.GetDoctorById(id);
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
