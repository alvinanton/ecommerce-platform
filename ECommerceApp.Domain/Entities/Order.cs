using EcommerceApp.Domain.Common;
using ECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceApp.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string OrderNumber { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required, MaxLength(20)]
        public string Status { get; set; } = "Pending";

        [MaxLength(100)]
        public string PaymentIntentId { get; set; } = string.Empty;

        public DateTime? CompletedAt { get; set; }

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
