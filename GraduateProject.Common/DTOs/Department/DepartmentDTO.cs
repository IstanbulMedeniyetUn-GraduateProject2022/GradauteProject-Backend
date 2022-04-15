using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.DTOs.Department
{
    public class DepartmentDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public virtual ICollection<DepartmentTranslateDTO> Translates { get; set; }
    }

    public class DepartmentTranslateDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public string LanguageId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
