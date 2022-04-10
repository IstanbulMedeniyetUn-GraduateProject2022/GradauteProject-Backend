using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    public partial class Department : BaseEntity<int>
    {
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<DepartmentTranslate> Translates { get; set; }

    }

    public class DepartmentTranslate : BaseEntityTranslate<int>
    {
        public int DepratmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey(nameof(DepratmentId))]
        public virtual Department Department { get; set; }
    }
}
