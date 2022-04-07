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
    public class RatingController : ControllerBase
    {
        private readonly GraduateProjectDbContext _context;

        public RatingController(GraduateProjectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Rating>>> GetItems()
        {
            return await _context.Ratings.ToListAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Rating>> GetItem(int id)
        {
            var item = await _context.Ratings.FindAsync(id);

            return (item == null || item.IsActive == false) ? NotFound() : Ok(item);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<Rating>> CreateItem(Rating item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.Ratings.Add(item);
                await _context.SaveChangesAsync();

                return Ok(item);

            }
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateItem(int id, Rating item)
        {
            if (id != item.RatingId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ratings.Update(item);
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id)) { return NotFound(); }
                else { throw; }
            }

            return Ok(item);
        }

        private bool ItemExists(int id)
        {
            return _context.Ratings.Any(e => e.RatingId == id);
        }
    }
}
