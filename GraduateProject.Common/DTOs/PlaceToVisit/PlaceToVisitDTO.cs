using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.DTOs.PlaceToVisit
{
    public class PlaceToVisitDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(14)]
        public string Phone { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public int RegionId { get; set; }

        [Required]
        public float Rate { get; set; } = 0;

        [Required]
        [StringLength(25)]
        public string WorkingTime { get; set; }

        [Required]
        [StringLength(25)]
        public string WorkingTimeWE { get; set; }

        [Required]
        [StringLength(100)]
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

        public virtual ICollection<PlaceToVisitTranslateDTO> Translates { get; set; }
        
    }

    public class PlaceToVisitTranslateDTO
    {
        public int Id { get; set; }

        public int PlaceToVisitId { get; set; }

        public string LanguageId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
