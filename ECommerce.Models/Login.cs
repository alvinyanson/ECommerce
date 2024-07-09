using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class LogIn
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
