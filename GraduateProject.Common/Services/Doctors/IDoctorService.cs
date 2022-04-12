using GraduateProject.Common.DTOs.Doctor;
using GraduateProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.Doctors
{
    public interface IDoctorsService
    {
        public Task<List<DoctorListDTO>> GetActivatedDoctors();
        public Task<List<DoctorListDTO>> GetUnActivatedDoctors();
        public Task<DoctorDTO> GetDoctorById(int id);
        public Task<bool> AddDoctor(DoctorDTO doctor);
        public Task<bool> UpdateDoctor(DoctorDTO doctor);
        public Task<bool> DeleteDoctor(int id);
        public Task<List<DoctorListDTO>> FilterDoctors(int? DepartmentId, int? cityId, int? rate);
    }
}
