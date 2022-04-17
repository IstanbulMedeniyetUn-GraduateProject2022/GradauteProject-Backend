using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.DTOs.Hotel
{
    public class HotelDTO
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
        public int RegionId { get; set; }

        public string WebSiteLink { get; set; }

        [StringLength(14)]
        public string WhatappNumber { get; set; }

        [StringLength(100)]
        public string LogoPath { get; set; }

        public IFormFile ImageFile { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        public virtual ICollection<HotelTranslateDTO> Translates { get; set; }
    }

    public class HotelTranslateDTO
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public string LanguageId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
