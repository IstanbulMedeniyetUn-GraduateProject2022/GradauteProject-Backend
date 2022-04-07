﻿using GraduateProject.Common.Models;
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

            if (item == null || item.IsActive == false)
                return NotFound();

            item.ClicksNumber++;
            _context.PlaceToVisits.Update(item);
            return Ok(item);
        }
    }
}
