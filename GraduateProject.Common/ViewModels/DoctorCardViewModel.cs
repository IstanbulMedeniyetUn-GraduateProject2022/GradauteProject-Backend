using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.ViewModels
{
    public class DoctorCardViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public float Rate { get; set; }

        public string ImagePath { get; set; }

        public string WebSiteLink { get; set; }

        public int ClicksNumber { get; set; }

        public string DepartmentName { get; set; }

        public string MedicalCenterName { get; set; }

        public string WorkingPlace { get; set; }

    }
}
