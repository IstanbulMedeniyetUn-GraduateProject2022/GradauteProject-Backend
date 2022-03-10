using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    [Table("DoctorLog")]
    public partial class DoctorLog
    {

        [Key]
        [Column("DoctorID")]
        public int DoctorId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(14)]
        public string Phone { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }
        [Required]
        [StringLength(6)]
        public string Gender { get; set; }
        [Required]
        [StringLength(100)]
        public string WorkingPlace { get; set; }
        [Required]
        [StringLength(25)]
        public string WorkingTime { get; set; }
        [Required]
        [StringLength(25)]
        public string City { get; set; }
        [StringLength(100)]
        public string ImagePath { get; set; }
        [StringLength(100)]
        public string WebSiteLink { get; set; }
        [StringLength(14)]
        public string WhatappNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string DoctorAddress { get; set; }
        [StringLength(100)]
        public string DoctorLocation { get; set; }
        [Column("DepartmentID")]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(100)]
        public string MedicalCenterName { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("DoctorLogs")]
        public virtual Department Department { get; set; }
    }
}
