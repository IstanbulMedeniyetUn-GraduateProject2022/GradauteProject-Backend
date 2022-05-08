using AutoMapper;
using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.Doctor;
using GraduateProject.Common.Enums;
using GraduateProject.Common.Extentions;
using GraduateProject.Common.Models;
using GraduateProject.Common.Services.Doctors;
using GraduateProject.Common.ViewModels;
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
            catch(Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<DoctorListDTO>>> GetUnActivatedDoctors()
        {
            try
            {
                var result = await _doctorsService.GetUnActivatedDoctors();
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
            catch(Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }

        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateDoctor(DoctorDTO doctor)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new ResponseResult(ResponseType.ModelNotValid, "Model State is Not Valid"));

                var result = await _doctorsService.UpdateDoctor(doctor);
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
        public async Task<ActionResult> AddDoctor(DoctorDTO doctor)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new ResponseResult(ResponseType.ModelNotValid, "Model State is Not Valid"));

                var result = await _doctorsService.AddDoctor(doctor);
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
        public async Task<ActionResult<DoctorDTO>> DeleteDoctor(int id)
        {
            try
            {
                var result = await _doctorsService.DeleteDoctor(id);
                if (result == false)
                    return Json(new ResponseResult(ResponseType.Error, "The result is null!!"));

                return Json(new ResponseResult(ResponseType.Success, result));

            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }

        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<DoctorViewModel>> GetDoctorByIdView(int id)
        {
            try
            {
                var result = await _doctorsService.GetDoctorByIdView(id);
                if (result == null)
                    return Json(new ResponseResult(ResponseType.Error, "The result is null!!"));

                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }
    }
}
