using GraduateProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services
{
    public interface IDoctorsService
    {
        public Task<List<Doctor>> GetAcitvatedDoctors();
        public Task<List<Doctor>> GetUnActivatedDoctors();
        public Task<Doctor> GetDoctorById();
        public Task<bool> AddDoctor(Doctor doctor);
        public Task<bool> UpdateDoctor(Doctor doctor);
        public Task<bool> DeleteDoctor(int id);
        public Task<List<Doctor>> FilterDoctors(int? DepartmentId, int? cityId, int? rate);
    }
}
