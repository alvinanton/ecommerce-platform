using ECommerceApp.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Domain.Entities
{
    public class Download : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public DateTime DownloadedAt { get; set; } = DateTime.UtcNow;

        [Required, MaxLength(45)]
        public string IpAddress { get; set; } = string.Empty;

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
