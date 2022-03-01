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
    public class HotelLogController : ControllerBase
    {
        private readonly GraduateProjectDbContext _context;

        public HotelLogController(GraduateProjectDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<HotelLog>> CreateItem(HotelLog item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.HotelLogs.Add(item);
                await _context.SaveChangesAsync();

                return Ok(item);

            }
        }
    }
}
