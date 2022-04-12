using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.DTOs.MedicalCenter
{
    public class MedicalCenterDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(14)]
        public string Phone { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        [StringLength(25)]
        public string WorkingTime { get; set; }

        [Required]
        [StringLength(25)]
        public string WorkingTimeWE { get; set; }

        [StringLength(100)]
        public string ImagePath { get; set; }

        public IFormFile ImageFile { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [StringLength(100)]
        public string WebSiteLink { get; set; }

        [StringLength(14)]
        public string WhatappNumber { get; set; }

        public virtual ICollection<MedicalCenterTranslateDTO> Translates { get; set; }
    }

    public class MedicalCenterTranslateDTO
    {
        public int Id { get; set; }

        public int MedicalCenterId { get; set; }

        public string LanguageId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
