using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Models.SysModels
{
    public class SysRegion : BaseEntityNoIdentity<int>
    {
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public SysCity SysCity { get; set; }    
        public ICollection<SysRegionTranslate> Translates { get; set; }
    }

    public class SysRegionTranslate : BaseEntityTranslate<int>
    {
        public int RegionId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(RegionId))]
        public virtual SysRegion SysRegion { get; set; }

    }
}
