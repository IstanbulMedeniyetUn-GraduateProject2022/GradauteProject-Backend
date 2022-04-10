using GraduateProject.Common.Data;
using GraduateProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateProject.UI.Services
{
    public class Filter //: IFilter
    {
        private readonly ApplicationDbContext _context;
        public Filter(ApplicationDbContext context)
        {
            _context = context;
        }
        /*
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
            else  //is this true logically or I should not return anything when no condition will be true//null
            {
                return await _context.Doctors.OrderByDescending(x => x.Rate).ToListAsync(); //return all of them
            }
        }

        public async Task<List<MedicalCenter>> FilterByCityOrRating(string? city, float? rating)
        {
            if ((string.IsNullOrEmpty(city) != true) && (rating != null)) //city, rating
            {
                return await _context.MedicalCenters.Where(x => (x.City.ToLower() == city.ToLower()) && (x.Rate >= rating)).OrderByDescending(x => x.Rate).ToListAsync();
            }
            else if ((rating != null) && (string.IsNullOrEmpty(city) == true))//rating
            {
                return await _context.MedicalCenters.Where(x=> x.Rate >= rating).OrderByDescending(x => x.Rate).ToListAsync();
            }
            else if ((string.IsNullOrEmpty(city) != true) && (rating == null)) //city
            {
                return await _context.MedicalCenters.Where(x => x.City.ToLower() == city.ToLower()).OrderByDescending(x => x.Rate).ToListAsync();
            }
            else //is this logically true or I should not return anything when no condition will be true
            {
                return await _context.MedicalCenters.OrderByDescending(x => x.Rate).ToListAsync(); //return all of them
            }
        }*/
    }
}

