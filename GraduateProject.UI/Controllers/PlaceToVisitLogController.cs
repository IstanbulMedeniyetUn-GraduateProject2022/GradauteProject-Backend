using GraduateProject.Common.Models;
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
    public class PlaceToVisitLogController : ControllerBase
    {
        private readonly GraduateProjectDbContext _context;

        public PlaceToVisitLogController(GraduateProjectDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<PlaceToVisitLog>> CreateItem(PlaceToVisitLog item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.PlaceToVisitLogs.Add(item);
                await _context.SaveChangesAsync();

                return Ok(item);

            }
        }
    }
}
