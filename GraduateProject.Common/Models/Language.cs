using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    [Table("Language")]
    public partial class Language
    {
        public Language()
        {
            Comments = new HashSet<Comment>();
            Doctors = new HashSet<Doctor>();
            Hotels = new HashSet<Hotel>();
            MedicalCenters = new HashSet<MedicalCenter>();
            PlaceToVisits = new HashSet<PlaceToVisit>();
        }

        [Key]
        [Column("LanguageID")]
        public int LanguageId { get; set; }
        [Required]
        [Column("Language")]
        [StringLength(50)]
        public string Language1 { get; set; }
        [Required]
        [StringLength(10)]
        public string LanguageCode { get; set; }

        [InverseProperty(nameof(Comment.Language))]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty(nameof(Doctor.Language))]
        public virtual ICollection<Doctor> Doctors { get; set; }
        [InverseProperty(nameof(Hotel.Language))]
        public virtual ICollection<Hotel> Hotels { get; set; }
        [InverseProperty(nameof(MedicalCenter.Language))]
        public virtual ICollection<MedicalCenter> MedicalCenters { get; set; }
        [InverseProperty(nameof(PlaceToVisit.Language))]
        public virtual ICollection<PlaceToVisit> PlaceToVisits { get; set; }
    }
}
