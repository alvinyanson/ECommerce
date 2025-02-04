﻿
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string BriefDescription { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }

        [Required]
        public double Price { get; set; }

        public virtual List<ProductCategory>? Category { get; set; }
    }
}
