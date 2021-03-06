using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Models.SysModels
{
    public class SysPlaceType : BaseEntityNoIdentity<int>
    {
        public ICollection<SysPlaceTypeTranslate> Translates { get; set; }
    }

    public class SysPlaceTypeTranslate : BaseEntityTranslate<int>
    {
        public int PlaceTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(PlaceTypeId))]
        public SysPlaceType SysPlaceType { get; set; }
    }
}
