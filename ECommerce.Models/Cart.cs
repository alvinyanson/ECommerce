using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace ECommerce.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public virtual IdentityUser Owner { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ValidateNever]
        public virtual Product Product { get; set; }

        [DefaultValue(0)]
        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Quantity { get; set; }
    }
}
