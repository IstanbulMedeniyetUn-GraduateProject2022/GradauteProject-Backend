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
    public class DoctorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetItems()/////////////
        {
            return await _context.Doctors.Where(d => d.IsActive == true).ToListAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Doctor>> GetItem(int id)
        {
            var item = await _context.Doctors.FindAsync(id);

            if (item == null || item.IsActive == false)
                return NotFound();
            
            item.ClicksNumber ++;
            _context.Doctors.Update(item);

            //this approach is used for calculating the three doctors that that should have the same rating, and that because we used AR, EN, TUR in db 
            /*float rate = 0;
            if (item.DoctorId % 3 == 0 && item.DoctorId != 0)//like 3=> 3 ,2, 1
            {
                Rating R1 = (from x in item.Ratings.OfType<Rating>() where x.DoctorId == item.DoctorId select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in item.Ratings.OfType<Rating>() where x.DoctorId == (item.DoctorId - 1) select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in item.Ratings.OfType<Rating>() where x.DoctorId == (item.DoctorId - 2) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }
            else if (item.DoctorId % 3 == 2)//like 5=> 4 ,5, 6
            {
                Rating R1 = (from x in item.Ratings.OfType<Rating>() where x.DoctorId == (item.DoctorId - 1) select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in item.Ratings.OfType<Rating>() where x.DoctorId == item.DoctorId select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in item.Ratings.OfType<Rating>() where x.DoctorId == (item.DoctorId + 1) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }
            else  //(DoctorId % 3 == 1)like 4 => 4 ,5, 6
            {
                List<float> ratings = (from x in item.Ratings.OfType<Rating>() where x.DoctorId == item.DoctorId select x.Rate).ToList();

                ratings.AddRange((from x in item.Ratings.OfType<Rating>() where x.DoctorId == (item.DoctorId + 1) select x.Rate).ToList());

                ratings.AddRange((from x in item.Ratings.OfType<Rating>() where x.DoctorId == (item.DoctorId + 2) select x.Rate).ToList());
                rate = ratings.Average();
            }
            item.Rate = rate;
            */
            return Ok(item);
        }
    }
}
