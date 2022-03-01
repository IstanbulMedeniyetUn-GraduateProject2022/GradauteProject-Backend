using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        [Column("CommentID")]
        public int CommentId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserFirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string UserLastName { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
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
        [Column("LanguageID")]
        public int? LanguageId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        [InverseProperty("Comments")]
        public virtual Doctor Doctor { get; set; }
        [ForeignKey(nameof(HotelId))]
        [InverseProperty("Comments")]
        public virtual Hotel Hotel { get; set; }
        [ForeignKey(nameof(LanguageId))]
        [InverseProperty("Comments")]
        public virtual Language Language { get; set; }
        [ForeignKey(nameof(MedicalCenterId))]
        [InverseProperty("Comments")]
        public virtual MedicalCenter MedicalCenter { get; set; }
        [ForeignKey(nameof(PlaceId))]
        [InverseProperty(nameof(PlaceToVisit.Comments))]
        public virtual PlaceToVisit Place { get; set; }
    }
}
