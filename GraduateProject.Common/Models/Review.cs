using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    public class Review : BaseEntity<int>
    {
        public Review() 
        { 
            if (!(Rate >= 0 && Rate <= 5)) 
                throw new InvalidOperationException("Rating should be between 0 and 5"); 
        }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        public string Description { get; set; }

        [Required]
        public float Rate { get; set; }

        [Required]
        public int ReferenceId { get; set; }

        [Required]
        public string ReferenceType { get; set; }
    }

}
