using GraduateProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateProject.UI.Services
{
    public class Filter : IFilter
    {
        private readonly GraduateProjectDbContext _context;
        public Filter(GraduateProjectDbContext context)
        {
            _context = context;
        }
        public async Task <List<Doctor>> FilterByCityOrDepartmentOrRating(string? city, int? id, float? rating)
        {
            if ((string.IsNullOrEmpty(city) != true) && (id != null) && (rating != null)) //city, and id, rating
            {
                 return await _context.Doctors.Where(x => (x.City.ToLower() == city.ToLower()) && (x.DepartmentId == id) && (x.Rate >= rating)).OrderByDescending(x => x.Rate).ToListAsync();
            }
            else if ((string.IsNullOrEmpty(city) == true) && (id != null) && (rating != null))//id and rating
            {
                return await _context.Doctors.Where(x => (x.DepartmentId == id) && (x.Rate >= rating)).OrderByDescending(x => x.Rate).ToListAsync();
            }
            else if ((string.IsNullOrEmpty(city) == true) && (id == null) && (rating != null))//rating
            {
                return await _context.Doctors.Where(x => (x.Rate >= rating)).OrderByDescending(x => x.Rate).ToListAsync();
            }
            else if ((string.IsNullOrEmpty(city) != true) && (id == null) && (rating != null))//city and rating
            {
                return await _context.Doctors.Where(x => (x.City.ToLower() == city.ToLower()) && (x.Rate >= rating)).OrderByDescending(x => x.Rate).ToListAsync();
            }
            else if ((string.IsNullOrEmpty(city) == true) && (id != null) && (rating == null)) // id
            {
                return await _context.Doctors.Where(x => x.DepartmentId == id).OrderByDescending(x => x.Rate).ToListAsync();
            }
            else if ((string.IsNullOrEmpty(city) != true) && (id == null) && (rating == null)) //city
            {
                return await _context.Doctors.Where(x => x.City.ToLower() == city.ToLower()).OrderByDescending(x => x.Rate).ToListAsync();
            }
            else if ((string.IsNullOrEmpty(city) != true) && (id != null) && (rating == null)) //city, and id
            {
                return await _context.Doctors.Where(x => (x.City.ToLower() == city.ToLower()) && (x.DepartmentId == id)).OrderByDescending(x => x.Rate).ToListAsync();
            }
            else
            {
                return await _context.Doctors.OrderByDescending(x => x.Rate).ToListAsync(); //return all of them
            }
        }
    }
}

