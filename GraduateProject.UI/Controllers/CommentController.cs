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

            return item == null ? NotFound() : Ok(item);
        }
    }
}
