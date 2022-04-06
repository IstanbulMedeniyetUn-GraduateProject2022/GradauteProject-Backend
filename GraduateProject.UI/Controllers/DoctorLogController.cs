using GraduateProject.Common.Models;
using GraduateProject.UI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateProject.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorLogController : ControllerBase
    {
        private readonly GraduateProjectDbContext _context;
        private readonly IMailingService _mailingService;
        public DoctorLogController(GraduateProjectDbContext context, IMailingService mailingService)
        {
            _context = context;
            _mailingService = mailingService;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<DoctorLog>> CreateItem(DoctorLog item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.DoctorLogs.Add(item);
                await _context.SaveChangesAsync();

                // for sending a welcoming email
                var filePath = $"{Directory.GetCurrentDirectory()}\\Templates\\EmailTemplate.html";
                var str = new StreamReader(filePath);

                var mailText = str.ReadToEnd();
                str.Close();

                mailText = mailText.Replace("[username]", item.FirstName + " " + item.LastName).Replace("[email]", item.Email);

                await _mailingService.SendEmailAsync(item.Email, "Welcome to our project", mailText);
                return Ok(item);
            }
        }

    }
    
}
