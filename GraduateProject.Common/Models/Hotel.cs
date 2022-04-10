using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using GraduateProject.Common.Models.SysModels;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    public class Hotel : BaseEntity<int> 
    {
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(14)]
        public string Phone { get; set; }

        [Required]
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public SysCity City { get; set; }

        [StringLength(100)]
        [Required]
        public float Rate { get; set; } = 0;

        public string WebSiteLink { get; set; }

        [StringLength(14)]
        public string WhatappNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string LogoPath { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        public int ClicksNumber { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<HotelTranslate> Translates { get; set; }
    }

    public class HotelTranslate : BaseEntity<int>
    {
        public int HotelId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [ForeignKey(nameof(HotelId))]
        public virtual Hotel Hotel { get; set; }

    }
}
