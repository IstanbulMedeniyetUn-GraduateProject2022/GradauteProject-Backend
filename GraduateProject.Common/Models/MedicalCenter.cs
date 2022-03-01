using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    [Table("MedicalCenter")]
    public partial class MedicalCenter
    {
        public MedicalCenter()
        {
            Comments = new HashSet<Comment>();
            Doctors = new HashSet<Doctor>();
            Ratings = new HashSet<Rating>();
        }

        [Key]
        [Column("MedicalCenterID")]
        public int MedicalCenterId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(14)]
        public string Phone { get; set; }
        [Required]
        [StringLength(25)]
        public string City { get; set; }
        [Required]
        [StringLength(15)]
        public string OpeningTime { get; set; }
        [Required]
        [StringLength(15)]
        public string ClosingTime { get; set; }
        [Required]
        [StringLength(100)]
        public string ImagePath { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [StringLength(100)]
        public string Location { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        [StringLength(100)]
        public string WebSiteLink { get; set; }
        [StringLength(14)]
        public string WhatappNumber { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Column("LanguageID")]
        public int? LanguageId { get; set; }
        [Required]
        public int ClicksNumber { get; set; }

        [ForeignKey(nameof(LanguageId))]
        [InverseProperty("MedicalCenters")]
        public virtual Language Language { get; set; }
        [InverseProperty(nameof(Comment.MedicalCenter))]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty(nameof(Doctor.MedicalCenter))]
        public virtual ICollection<Doctor> Doctors { get; set; }
        [InverseProperty(nameof(Rating.MedicalCenter))]
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
