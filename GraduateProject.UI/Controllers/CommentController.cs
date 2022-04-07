using GraduateProject.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateProject.UI.Controllers
{
    public class CommentController : Controller
    {
        private readonly GraduateProjectDbContext _context;
        public CommentController(GraduateProjectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetItems()
        {
            return await _context.Comments.ToListAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Comment>> GetItem(int id)
        {
            var item = await _context.Comments.FindAsync(id);

            return (item == null || item.IsActive == false) ? NotFound() : Ok(item);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<Comment>> CreateItem(Comment item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.Comments.Add(item);
                await _context.SaveChangesAsync();

                return Ok(item);

            }
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateItem(int id, Comment item)
        {
            if (id != item.CommentId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Comments.Update(item);
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id)) { return NotFound();  }
                else { throw; }
            }

            return Ok(item);
        }

        private bool ItemExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }

    }
}
