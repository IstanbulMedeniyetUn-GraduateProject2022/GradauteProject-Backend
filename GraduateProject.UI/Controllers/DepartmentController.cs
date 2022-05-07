using GraduateProject.Common.Data;
using GraduateProject.Common.DTOs.Department;
using GraduateProject.Common.Enums;
using GraduateProject.Common.Extentions;
using GraduateProject.Common.Models;
using GraduateProject.Common.Services.Lookups;
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
    public class DepartmentController : Controller
    {
        #region Fields and Ctor
        private readonly ILookupsCRUDService _lookupsCRUDService;
        public DepartmentController(ILookupsCRUDService lookupsCRUDService)
        {
            _lookupsCRUDService = lookupsCRUDService;
        }
        #endregion

        #region Methods

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<List<DepartmentDTO>>>> GetSysDepartment() 
        {
            try
            {
                var result = await _lookupsCRUDService.GetSysDepartments();
                return Json(new ResponseResult(ResponseType.Success, result));
            }
            catch(Exception ex)
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
            catch(Exception ex)
            {
                return Json(new ResponseResult(ResponseType.Error, ex.GetError()));
            }
        }

        #endregion
    }
}
