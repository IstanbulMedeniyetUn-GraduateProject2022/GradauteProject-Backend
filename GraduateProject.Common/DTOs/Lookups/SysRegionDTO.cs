using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.DTOs.Lookups
{
    public class SysRegionDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CityId { get; set; }

        public string CityName { get; set; }

        public List<SysRegionTranslateDTO> Translates { get; set; }
    }

    public class SysRegionTranslateDTO
    {
        public int Id { get; set; }

        [Required]
        public int RegionId { get; set; }

        [Required]
        public string LanguageId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
