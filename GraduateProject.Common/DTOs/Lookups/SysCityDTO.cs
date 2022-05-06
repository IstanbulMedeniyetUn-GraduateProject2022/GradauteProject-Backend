using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.DTOs.Lookups
{
    public class SysCityDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<SysCityTranslateDTO> Translates { get; set; }
    }

    public class SysCityTranslateDTO
    {
        public int Id { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public string LanguageId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
