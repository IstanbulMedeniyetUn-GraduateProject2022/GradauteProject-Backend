using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    [Table("Rating")]
    public partial class Rating
    {
        public Rating() 
        { 
            if (!(Rate >= 0 && Rate <= 5)) 
                throw new InvalidOperationException("Rating should be between 0 and 5"); 
        }

        [Key]
        [Column("RatingID")]
        public int RatingId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserFirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string UserLastName { get; set; }
        public float Rate { get; set; }
        [Column("DoctorID")]
        public int? DoctorId { get; set; }
        [Column("HotelID")]
        public int? HotelId { get; set; }
        [Column("PlaceID")]
        public int? PlaceId { get; set; }
        [Column("MedicalCenterID")]
        public int? MedicalCenterId { get; set; }
        [Column("WebSiteID")]
        public int? WebSiteId { get; set; }
        [Required]
        public bool IsActive { get; set; }

        [ForeignKey(nameof(DoctorId))]
        [InverseProperty("Ratings")]
        public virtual Doctor Doctor { get; set; }
        [ForeignKey(nameof(HotelId))]
        [InverseProperty("Ratings")]
        public virtual Hotel Hotel { get; set; }
        [ForeignKey(nameof(MedicalCenterId))]
        [InverseProperty("Ratings")]
        public virtual MedicalCenter MedicalCenter { get; set; }
        [ForeignKey(nameof(PlaceId))]
        [InverseProperty(nameof(PlaceToVisit.Ratings))]
        public virtual PlaceToVisit Place { get; set; }
    }
}
