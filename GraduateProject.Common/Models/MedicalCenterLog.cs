using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    [Table("MedicalCenterLog")]
    public partial class MedicalCenterLog
    {
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
        [StringLength(100)]
        public string ImagePath { get; set; }
        [StringLength(100)]
        public string WebSiteLink { get; set; }
        [StringLength(14)]
        public string WhatappNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(100)]
        public string Location { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
