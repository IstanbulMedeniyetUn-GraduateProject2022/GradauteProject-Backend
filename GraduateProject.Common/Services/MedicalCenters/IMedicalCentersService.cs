using GraduateProject.Common.DTOs.MedicalCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.MedicalCenters
{
    public interface IMedicalCentersService
    {
        public Task<List<MedicalCenterListDTO>> GetAcitvatedMedicalCenters();
        public Task<List<MedicalCenterListDTO>> GetUnActivatedMedicalCenters();
        public Task<MedicalCenterDTO> GetMedicalCenterById(int id);
        public Task<bool> AddMedicalCenter(MedicalCenterDTO doctor);
        public Task<bool> UpdateMedicalCenter(MedicalCenterDTO doctor);
        public Task<bool> DeleteMedicalCenter(int id);
        public Task<List<MedicalCenterListDTO>> FilterMedicalCenters(int? cityId, int? rate);
    }
}
