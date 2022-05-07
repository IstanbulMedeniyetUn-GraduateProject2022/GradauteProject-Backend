using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.Department;
using GraduateProject.Common.Enums;
using GraduateProject.Common.Extentions;
using GraduateProject.Common.Models;
using GraduateProject.Common.Services.Lookups;
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
    public class DepartmentController : Controller
    {
        private readonly ILookupsCRUDService _lookupsCRUDService;
        public DepartmentController(ILookupsCRUDService lookupsCRUDService)
        {
            _lookupsCRUDService = lookupsCRUDService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<List<DepartmentDTO>>>> GetSysDepartments()
        {
            try
            {
                var result = await _lookupsCRUDService.GetSysDepartments();
                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<List<DepartmentDTO>>>> DepartmentList()
        {
            try
            {
                var result = await _lookupsCRUDService.DepartmentList();
                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<DepartmentDTO>> GetDepartmentById(int id)
        {
            try
            {
                var result = await _lookupsCRUDService.GetDepartmentById(id);
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
        public async Task<IActionResult> UpdateDepartment(DepartmentDTO department)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new ResponseResult(ResponseType.ModelNotValid, "Model State is Not Valid"));

                var result = await _lookupsCRUDService.UpdateDepartment(department);
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
        public async Task<ActionResult> AddDepartment(DepartmentDTO department)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new ResponseResult(ResponseType.ModelNotValid, "Model State is Not Valid"));

                var result = await _lookupsCRUDService.AddDepartment(department);
                if (result == null)
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
        public async Task<ActionResult<DepartmentDTO>> DeleteDepartment(int id)
        {
            try
            {
                var result = await _lookupsCRUDService.DeleteDepartment(id);
                if (result == false)
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
