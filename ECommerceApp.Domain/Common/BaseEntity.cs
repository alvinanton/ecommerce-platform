using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceApp.Domain.Common
{
    /// <summary>
    /// Base entity with common properties for all entities
    /// </summary>
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
