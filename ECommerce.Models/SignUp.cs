using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ECommerce.Models
{
    public class SignUp
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public int Role { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
