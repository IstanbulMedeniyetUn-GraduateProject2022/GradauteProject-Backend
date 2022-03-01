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
    public class PlaceToVisitController : ControllerBase
    {
        private readonly GraduateProjectDbContext _context;

        public PlaceToVisitController(GraduateProjectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<PlaceToVisit>>> GetItems()
        {
            return await _context.PlaceToVisits.ToListAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<PlaceToVisit>> GetItem(int id)
        {
            var item = await _context.PlaceToVisits.FindAsync(id);

            return item == null ? NotFound() : Ok(item);
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateItem(int id, PlaceToVisit item)
        {
            if (id != item.PlaceId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PlaceToVisits.Update(item);
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
        public async Task<ActionResult<PlaceToVisit>> CreateItem(PlaceToVisit item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.PlaceToVisits.Add(item);
                await _context.SaveChangesAsync();

                return Ok(item);

            }
        }


        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult<PlaceToVisit>> DeleteItem(int id)
        {
            var item = await _context.PlaceToVisits.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.PlaceToVisits.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        private bool ItemExists(int id)
        {
            return _context.PlaceToVisits.Any(e => e.PlaceId == id);
        }


    }
}
