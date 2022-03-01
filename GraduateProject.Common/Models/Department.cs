using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GraduateProject.Common.Models
{
    [Table("Department")]
    public partial class Department
    {
        public Department()
        {
            DoctorLogs = new HashSet<DoctorLog>();
            Doctors = new HashSet<Doctor>();
        }

        [Key]
        [Column("DepartmentID")]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int ClicksNumber { get; set; }

        [InverseProperty(nameof(DoctorLog.Department))]
        public virtual ICollection<DoctorLog> DoctorLogs { get; set; }
        [InverseProperty(nameof(Doctor.Department))]
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
