using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.DTOs.Lookups
{
    public class SysPlaceTypeDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<SysPlaceTypeTranslateDTO> Translates { get; set; }

    }

    public class SysPlaceTypeTranslateDTO
    {
        public int Id { get; set; }

        [Required]
        public int PlaceTypeId { get; set; }

        [Required]
        public string LanguageId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
