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
    public class DepartmentController : ControllerBase
    {
        private readonly GraduateProjectDbContext _context;

        public DepartmentController(GraduateProjectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Department>>> GetItems()
        {
            return await _context.Departments.ToListAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Department>> GetItem(int id)
        {
            var item = await _context.Departments.FindAsync(id);

            return item == null ? NotFound() : Ok(item);
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateItem(int id, Department item)
        {
            if (id != item.DepartmentId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Departments.Update(item);
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
        public async Task<ActionResult<Department>> CreateItem(Department item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.Departments.Add(item);
                await _context.SaveChangesAsync();

                return Ok(item);

            }
        }


        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Department>> DeleteItem(int id)
        {
            var item = await _context.Departments.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        private bool ItemExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }


    }
}
