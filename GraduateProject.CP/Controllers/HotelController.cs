using GraduateProject.Common.Data;
using GraduateProject.Common.Models;
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
    public class HotelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelController(ApplicationDbContext context)
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

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateItem(int id, Hotel item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Hotels.Update(item);
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(item);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<Doctor>> CreateItem(Hotel item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.Hotels.Add(item);
                await _context.SaveChangesAsync();

                return Ok(item);

            }
        }


        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Hotel>> DeleteItem(int id)
        {
            var item = await _context.Hotels.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        private bool ItemExists(int id)
        {
            return _context.Hotels.Any(e => e.Id == id);
        }


    }
}
