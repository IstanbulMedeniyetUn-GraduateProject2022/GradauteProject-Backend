using GraduateProject.Common.Data;
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
    public class ReviewController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Review>>> GetItems()
        {
            return await _context.Reviews.ToListAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Review>> GetItem(int id)
        {
            var item = await _context.Reviews.FindAsync(id);

            return (item == null || item.IsActive == false) ? NotFound() : Ok(item);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<Review>> CreateItem(Review item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.Reviews.Add(item);
                await _context.SaveChangesAsync();

                return Ok(item);

            }
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateItem(int id, Review item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Reviews.Update(item);
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
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
