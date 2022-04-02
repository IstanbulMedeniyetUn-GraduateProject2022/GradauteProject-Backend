using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

            //this approach is used for calculating the three Hotels that that should have the same rating, and that because we used AR, EN, TUR in db 
            float FirstRating, SecondRating, ThirdRating;

            if (HotelId % 3 == 0)//like 3=> 3 ,2, 1
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.HotelId == HotelId select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.HotelId == (HotelId - 1) select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.HotelId == (HotelId - 2) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }

            else if (HotelId % 3 == 2)//like 5=> 4 ,5, 6
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.HotelId == (HotelId - 1) select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.HotelId == HotelId select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.HotelId == (HotelId + 1) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }
            else  //(HotelId % 3 == 1)like 4 => 4 ,5, 6
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.HotelId == HotelId select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.HotelId == (HotelId + 1) select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.HotelId == (HotelId + 2) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }
            Rate = (FirstRating + SecondRating + ThirdRating) / 3;
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

        [Required]
        public float Rate { get; set; }
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
