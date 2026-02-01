using EcommerceApp.Domain.Common;
using EcommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerceApp.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(250)]
        public string? Description { get; set; }

        public int? ParentCategoryId { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual Category? ParentCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
