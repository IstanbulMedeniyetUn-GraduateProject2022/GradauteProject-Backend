using GraduateProject.Common.Models;
using GraduateProject.UI.Services;
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
    public class FilterController : ControllerBase
    {
        private readonly IFilter _filter;

        public FilterController(IFilter filter)
        {
            _filter = filter;
        }

        [HttpGet] //post
        [Route("[action]/{City?}/{Department?}/{Rating?}")]
        public async Task<IActionResult> FilterByCityOrDepartmentOrRating(string? city, int? id, float? rating)
        {
            var doctors = await _filter.FilterByCityOrDepartmentOrRating(city, id, rating);
            if (doctors != null)
            {
                return Ok(doctors);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{City?}/{Rating?}")]
        public async Task<IActionResult> FilterByCityOrRating(string? city, float? rating)
        {
            var medicalCenters = await _filter.FilterByCityOrRating(city, rating);
            if (medicalCenters != null)
            {
                return Ok(medicalCenters);
            }
            return NotFound();
        }
    }
}
