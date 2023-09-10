using Microsoft.Build.Framework;

namespace webapi.Models
{
    public class UserRegister
    {
        [Required]
        public string? UserName { get; set; }
        [Required]

        public string? Password { get; set; }
        [Required()]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
