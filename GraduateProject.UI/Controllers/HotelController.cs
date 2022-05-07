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
    public class HotelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetItems()
        {
            return await _context.Hotels.ToListAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Hotel>> GetItem(int id)
        {
            var item = await _context.Hotels.FindAsync(id);

            if (item == null || item.IsActive == false)
                return NotFound();

            item.ClicksNumber++;
            _context.Hotels.Update(item);
            /*
             * //this approach is used for calculating the three Hotels that that should have the same rating, and that because we used AR, EN, TUR in db 
            float FirstRating, SecondRating, ThirdRating;

            if (HotelId % 3 == 0)//like 3=> 3 ,2, 1
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.HotelId == HotelId select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.HotelId == (HotelId - 1) select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.HotelId == (HotelId - 2) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }

            else if (HotelId % 3 == 2)//like 5=> 4 ,5, 6
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.HotelId == (HotelId - 1) select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.HotelId == HotelId select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.HotelId == (HotelId + 1) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }
            else  //(HotelId % 3 == 1)like 4 => 4 ,5, 6
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.HotelId == HotelId select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.HotelId == (HotelId + 1) select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.HotelId == (HotelId + 2) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }
            Rate = (FirstRating + SecondRating + ThirdRating) / 3;
             */
            return Ok(item);
        }
    }
}
