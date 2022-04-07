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
    public class MedicalCenterController : ControllerBase
    {
        private readonly GraduateProjectDbContext _context;

        public MedicalCenterController(GraduateProjectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<MedicalCenter>>> GetItems()
        {
            return await _context.MedicalCenters.ToListAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<MedicalCenter>> GetItem(int id)
        {
            var item = await _context.MedicalCenters.FindAsync(id);

            if (item == null || item.IsActive == false)
                return NotFound();

            item.ClicksNumber++;
            _context.MedicalCenters.Update(item);
            return Ok(item);
        }
    }
}
