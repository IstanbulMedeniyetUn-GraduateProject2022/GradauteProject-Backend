using GraduateProject.Common.Data;
using GraduateProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services
{
    public class DoctorsService : IDoctorsService
    {
        public ApplicationDbContext _context;

        public DoctorsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> AddDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Doctor>> FilterDoctors(int? DepartmentId, int? cityId, int? rate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Doctor>> GetAcitvatedDoctors()
        {
            try
            {
                var doctors = await _context.Doctors.Where(d => d.IsActive == true).ToListAsync();
                return doctors;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Task<Doctor> GetDoctorById()
        {
            throw new NotImplementedException();
        }

        public Task<List<Doctor>> GetUnActivatedDoctors()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
