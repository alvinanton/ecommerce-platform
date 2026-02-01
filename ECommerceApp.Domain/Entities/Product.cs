using EcommerceApp.Domain.Common;
using ECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceApp.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [MaxLength(250)]
        public string ShortDescription { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public bool IsDigital { get; set; } = true;

        [MaxLength(500)]
        public string? FileUrl { get; set; }

        public long? FileSize { get; set; }

        [MaxLength(500)]
        public string? ThumbnailUrl { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


    }
}
