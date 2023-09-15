using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class UserLoginModel
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }

    }
}
