using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.Doctor;
using GraduateProject.Common.Enums;
using GraduateProject.Common.Extentions;
using GraduateProject.Common.Models;
using GraduateProject.Common.Services.Doctors;
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
        private readonly ApplicationDbContext _context;

        private readonly IDoctorsService _doctorsService;

        public DoctorController(ApplicationDbContext context, IDoctorsService doctorsService)
        {
            _context = context;
            _doctorsService = doctorsService;  
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<DoctorListDTO>>> GetActivatedDoctors()
        {
            try
            {
                var result = await _doctorsService.GetActivatedDoctors();
                return result;
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
                return result;
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
                    return Json(new ResponseResult(ResponseType.Success, result.ToString()));
                return result;
            }
            catch(Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }

        }

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateItem(int id, Doctor item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Doctors.Update(item);
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(item);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<Doctor>> CreateItem(Doctor item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.Doctors.Add(item);
                await _context.SaveChangesAsync();

                return Ok(item);

            }
        }


        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Doctor>> DeleteItem(int id)
        {
            var item = await _context.Doctors.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        private bool ItemExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }


    }
}
