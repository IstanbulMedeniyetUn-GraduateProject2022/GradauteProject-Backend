using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using GraduateProject.Common.Models.SysModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    public class Doctor : BaseEntity<int>
    {
        
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(14)]
        public string Phone { get; set; }
        
        public DateTime Birthday { get; set; }

        public float Rate { get; set; } = 0;

        [Required]
        [StringLength(25)]
        public string WorkingTime { get; set; }

        [Required]
        [StringLength(25)]
        public string WorkingTimeWE { get; set; }

        
        public string ImagePath { get; set; }


        [StringLength(100)]
        public string WebSiteLink { get; set; }

        [StringLength(14)]
        public string WhatappNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public SysCity City { get; set; }

        [Required]
        public int RegionId { get; set; }

        [ForeignKey(nameof(RegionId))]
        public SysRegion Region { get; set; }

        public int ClicksNumber { get; set; } = 0;

        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        public int? MedicalCenterId { get; set; }
       
        [ForeignKey(nameof(MedicalCenterId))]
        public virtual MedicalCenter MedicalCenter { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<DoctorTranslate> Translates { get; set; }

    }

    public class DoctorTranslate : BaseEntityTranslate<int>
    {
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

        [ForeignKey(nameof(DoctorId))]
        public virtual Doctor Doctor { get; set; }
    }
}
