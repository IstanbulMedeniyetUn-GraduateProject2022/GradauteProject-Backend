using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

            //this approach is used for calculating the three doctors that that should have the same rating, and that because we used AR, EN, TUR in db 
            float FirstRating, SecondRating, ThirdRating;

            if (DoctorId % 3 == 0)//like 3=> 3 ,2, 1
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.DoctorId == DoctorId select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.DoctorId == (DoctorId - 1) select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.DoctorId == (DoctorId - 2) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }

            else if (DoctorId % 3 == 2)//like 5=> 4 ,5, 6
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.DoctorId == (DoctorId - 1) select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.DoctorId == DoctorId select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.DoctorId == (DoctorId + 1) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }
            else  //(DoctorId % 3 == 1)like 4 => 4 ,5, 6
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.DoctorId == DoctorId select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.DoctorId == (DoctorId + 1) select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.DoctorId == (DoctorId + 2) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }
            Rate = (FirstRating + SecondRating + ThirdRating) / 3;
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
        public float Rate { get; set; } = 0;

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

        //[Required]
        //public bool IsConfirmed { get; set; }

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
