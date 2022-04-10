using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(14)]
        public string Phone { get; set; }

        public DateTime? Birthday { get; set; }

        [Required]
        [StringLength(25)]
        public string WorkingTime { get; set; }

        [Required]
        [StringLength(25)]
        public string WorkingTimeWE { get; set; }

        [Required]
        [StringLength(100)]
        public string ImagePath { get; set; }

        public IFormFile ImageFile { get; set; }

        [StringLength(100)]
        public string WebSiteLink { get; set; }

        [StringLength(14)]
        public string WhatappNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        public int DepartmentId { get; set; }

        public int? MedicalCenterId { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual ICollection<DoctorTranslateDTO> Tranlates { get; set; }
    }

    public class DoctorTranslateDTO
    {
        public int Id { get; set; }
        public string LanguageId { get; set; }

        public int DoctorId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(6)]
        public string Gender { get; set; }

        [Required]
        [StringLength(100)]
        public string WorkingPlace { get; set; }
    }
}
