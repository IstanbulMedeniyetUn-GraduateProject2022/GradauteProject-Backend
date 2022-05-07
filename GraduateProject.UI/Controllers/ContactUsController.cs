using GraduateProject.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GraduateProject.Common.Data;

namespace GraduateProject.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ContactUsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ContactUs>> CreateItem(ContactUs item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.ContactUs.Add(item);
                await _context.SaveChangesAsync();
                return Ok(item);
            }
        }
    }
}
