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

            return item == null ? NotFound() : Ok(item);
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateItem(int id, MedicalCenter item)
        {
            if (id != item.MedicalCenterId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MedicalCenters.Update(item);
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
        public async Task<ActionResult<Doctor>> CreateItem(MedicalCenter item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.MedicalCenters.Add(item);
                await _context.SaveChangesAsync();

                return Ok(item);

            }
        }


        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Doctor>> DeleteItem(int id)
        {
            var item = await _context.MedicalCenters.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.MedicalCenters.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        private bool ItemExists(int id)
        {
            return _context.MedicalCenters.Any(e => e.MedicalCenterId == id);
        }


    }
}
