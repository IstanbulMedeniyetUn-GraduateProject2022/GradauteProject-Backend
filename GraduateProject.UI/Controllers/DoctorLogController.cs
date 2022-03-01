using GraduateProject.Common.Models;
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
    public class DoctorLogController : ControllerBase
    {
        private readonly GraduateProjectDbContext _context;

            public DoctorLogController(GraduateProjectDbContext context)
            {
                _context = context;
            }


            [HttpPost]
            [Route("[action]")]
            public async Task<ActionResult<DoctorLog>> CreateItem(DoctorLog item)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    _context.DoctorLogs.Add(item);
                    await _context.SaveChangesAsync();

                     return Ok(item);

                }
            }

    }
    
}
