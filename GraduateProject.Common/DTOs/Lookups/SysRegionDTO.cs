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

        public string Name { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public List<SysRegionTranslateDTO> Translates { get; set; }
    }

    public class SysRegionTranslateDTO
    {
        public int Id { get; set; }

        public int RegionId { get; set; }

        public string LanguageId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
