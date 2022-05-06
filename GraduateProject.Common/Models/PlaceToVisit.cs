using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using GraduateProject.Common.Models.SysModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    public class PlaceToVisit : BaseEntity<int>
    {

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(14)]
        public string Phone { get; set; }

        [Required]
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public SysCity City { get; set; }

        [Required]
        public int RegionId { get; set; }

        [ForeignKey(nameof(RegionId))]
        public SysRegion Region { get; set; }

        [Required]
        public float Rate { get; set; } = 0;

        [Required]
        [StringLength(25)]
        public string WorkingTime { get; set; }

        [Required]
        [StringLength(25)]
        public string WorkingTimeWE { get; set; }

        public string ImagePath { get; set; }


        [StringLength(100)]
        public string WebSiteLink { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        public int PlaceTypeId { get; set; }

        [ForeignKey(nameof(PlaceTypeId))]
        public SysPlaceType PlaceType { get; set; }

        public int ClicksNumber { get; set; } = 0;

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<PlaceToVisitTranslate> Translates { get; set; }

    }

    public class PlaceToVisitTranslate : BaseEntityTranslate<int>
    {
        public int PlaceToVisitId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [ForeignKey(nameof(PlaceToVisitId))]
        public PlaceToVisit PlaceToVisit { get; set; }
    }
}
