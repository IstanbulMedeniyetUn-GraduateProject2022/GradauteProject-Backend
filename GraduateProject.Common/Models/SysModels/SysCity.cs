using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Models.SysModels
{
    public class SysCity : BaseEntity<int>
    {
        public ICollection<SysCityTranslate> Translates { get; set; }
    }

    public class SysCityTranslate : BaseEntityTranslate<int>
    {
        public int CityId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(CityId))]
        public virtual SysCity City {get;set;}

    }
}
