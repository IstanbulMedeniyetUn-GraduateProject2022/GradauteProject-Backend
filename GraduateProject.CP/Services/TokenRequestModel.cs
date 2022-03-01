using System.ComponentModel.DataAnnotations;

namespace GraduateProject.CP.Services
{
    public class TokenRequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}