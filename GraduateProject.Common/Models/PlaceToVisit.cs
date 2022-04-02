using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

            //this approach is used for calculating the three places that that should have the same rating, and that because we used AR, EN, TUR in db 
            float FirstRating, SecondRating, ThirdRating;

            if (PlaceId % 3 == 0)//like 3=> 3 ,2, 1
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.PlaceId == PlaceId select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.PlaceId == (PlaceId - 1) select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.PlaceId == (PlaceId - 2) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }

            else if (PlaceId % 3 == 2)//like 5=> 4 ,5, 6
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.PlaceId == (PlaceId - 1) select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.PlaceId == PlaceId select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.PlaceId == (PlaceId + 1) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }
            else  //(PlaceId % 3 == 1)like 4 => 4 ,5, 6
            {
                Rating R1 = (from x in Ratings.OfType<Rating>() where x.PlaceId == PlaceId select x)
                .SingleOrDefault();
                FirstRating = R1.Rate;

                Rating R2 = (from x in Ratings.OfType<Rating>() where x.PlaceId == (PlaceId + 1) select x)
                .SingleOrDefault();
                SecondRating = R2.Rate;

                Rating R3 = (from x in Ratings.OfType<Rating>() where x.PlaceId == (PlaceId + 2) select x)
                .SingleOrDefault();
                ThirdRating = R3.Rate;
            }
            Rate = (FirstRating + SecondRating + ThirdRating) / 3;
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
        public float Rate { get; set; }
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
