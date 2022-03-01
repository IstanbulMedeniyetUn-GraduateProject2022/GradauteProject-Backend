using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    [Table("Doctor")]
    public partial class Doctor
    {
        public Doctor()
        {
            Comments = new HashSet<Comment>();
            Ratings = new HashSet<Rating>();
        }

        [Key]
        [Column("DoctorID")]
        public int DoctorId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(14)]
        public string Phone { get; set; }
        [Required]
        [StringLength(6)]
        public string Gender { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }
        [Required]
        [StringLength(100)]
        public string WorkingPlace { get; set; }
        [Required]
        [StringLength(25)]
        public string WorkingTime { get; set; }
        [Required]
        [StringLength(25)]
        public string City { get; set; }
        [Required]
        [StringLength(100)]
        public string ImagePath { get; set; }
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
        [Column("DepartmentID")]
        public int DepartmentId { get; set; }
        [Column("MedicalCenterID")]
        public int? MedicalCenterId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Column("LanguageID")]
        public int? LanguageId { get; set; }
        [Required]
        public int ClicksNumber { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Doctors")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(LanguageId))]
        [InverseProperty("Doctors")]
        public virtual Language Language { get; set; }
        [ForeignKey(nameof(MedicalCenterId))]
        [InverseProperty("Doctors")]
        public virtual MedicalCenter MedicalCenter { get; set; }
        [InverseProperty(nameof(Comment.Doctor))]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty(nameof(Rating.Doctor))]
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
