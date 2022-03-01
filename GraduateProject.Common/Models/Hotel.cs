using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    [Table("Hotel")]
    public partial class Hotel
    {
        public Hotel()
        {
            Comments = new HashSet<Comment>();
            Ratings = new HashSet<Rating>();
        }

        [Key]
        [Column("HotelID")]
        public int HotelId { get; set; }
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
        [StringLength(100)]
        public string ImagePath { get; set; }
        [StringLength(100)]
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
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Column("LanguageID")]
        public int? LanguageId { get; set; }
        [Required]
        public int ClicksNumber { get; set; }

        [ForeignKey(nameof(LanguageId))]
        [InverseProperty("Hotels")]
        public virtual Language Language { get; set; }
        [InverseProperty(nameof(Comment.Hotel))]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty(nameof(Rating.Hotel))]
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
