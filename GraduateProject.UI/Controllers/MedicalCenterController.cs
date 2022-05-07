﻿using GraduateProject.Common.Data;
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
    public class MedicalCenterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MedicalCenterController(ApplicationDbContext context)
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

            if (item == null || item.IsActive == false)
                return NotFound();

            item.ClicksNumber++;
            _context.MedicalCenters.Update(item);
            /*
             //this approach is used for calculating the three medical centers that that should have the same rating, and that because we used AR, EN, TUR in db 
            float FirstRating, SecondRating, ThirdRating;

            if (MedicalCenterId % 3 == 0)//like 3=> 3 ,2, 1
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.MedicalCenterId == MedicalCenterId select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.MedicalCenterId == (MedicalCenterId - 1) select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.MedicalCenterId == (MedicalCenterId - 2) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }

            else if (MedicalCenterId % 3 == 2)//like 5=> 4 ,5, 6
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.MedicalCenterId == (MedicalCenterId - 1) select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.MedicalCenterId == MedicalCenterId select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.MedicalCenterId == (MedicalCenterId + 1) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }
            else  //(MedicalCenterId % 3 == 1)like 4 => 4 ,5, 6
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.MedicalCenterId == MedicalCenterId select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.MedicalCenterId == (MedicalCenterId + 1) select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.MedicalCenterId == (MedicalCenterId + 2) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }
            Rate = (FirstRating + SecondRating + ThirdRating) / 3;
             */
            return Ok(item);
        }
    }
}
