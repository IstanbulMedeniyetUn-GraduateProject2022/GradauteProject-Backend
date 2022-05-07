using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Models
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        //public string ImageFile { get; set; }

        [Required]
        [StringLength(14)]
        public string Phone { get; set; }

        [Required]
        [StringLength(1000)]
        public string Message { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
