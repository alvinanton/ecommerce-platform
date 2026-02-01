using EcommerceApp.Domain.Common;
using EcommerceApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required, MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? LastLoginAt { get; set; }

        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();


    }
}