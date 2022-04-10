using GraduateProject.Common.DTOs;
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
        public Task<List<DoctorDTO>> GetAcitvatedDoctors();
        public Task<List<DoctorDTO>> GetUnActivatedDoctors();
        public Task<DoctorDTO> GetDoctorById(int id);
        public Task<bool> AddDoctor(DoctorDTO doctor);
        public Task<bool> UpdateDoctor(DoctorDTO doctor);
        public Task<bool> DeleteDoctor(int id);
        public Task<List<DoctorDTO>> FilterDoctors(int? DepartmentId, int? cityId, int? rate);
    }
}
