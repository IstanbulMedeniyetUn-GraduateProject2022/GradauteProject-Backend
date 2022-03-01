using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    [Table("PlaceToVisit")]
    public partial class PlaceToVisit
    {
        public PlaceToVisit()
        {
            Comments = new HashSet<Comment>();
            Ratings = new HashSet<Rating>();
        }

        [Key]
        [Column("PlaceID")]
        public int PlaceId { get; set; }
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
        [Required]
        [StringLength(100)]
        public string Type { get; set; }
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
        [InverseProperty("PlaceToVisits")]
        public virtual Language Language { get; set; }
        [InverseProperty(nameof(Comment.Place))]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty(nameof(Rating.Place))]
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
