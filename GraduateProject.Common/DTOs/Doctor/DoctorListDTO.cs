using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.DTOs.Doctor
{
    public class DoctorListDTO
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string FullName { get; set; }

        public string DepartmentName { get; set; }

        public string MedicalCenterName { get;set; }

        public string Location { get; set; }
    }
}
