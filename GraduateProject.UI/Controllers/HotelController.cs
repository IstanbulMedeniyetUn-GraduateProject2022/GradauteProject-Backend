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
    public class HotelController : ControllerBase
    {
        private readonly GraduateProjectDbContext _context;

        public HotelController(GraduateProjectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetItems()
        {
            return await _context.Hotels.ToListAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Hotel>> GetItem(int id)
        {
            var item = await _context.Hotels.FindAsync(id);

            return item == null ? NotFound() : Ok(item);
        }
    }
}
