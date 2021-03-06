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
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
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

            return (item == null || item.IsActive == false) ? NotFound() : Ok(item);
        }
    }
}
