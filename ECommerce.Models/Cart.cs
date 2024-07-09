using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace ECommerce.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public virtual IdentityUser Owner { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [DefaultValue(0)]
        public int Quantity { get; set; }
    }
}
