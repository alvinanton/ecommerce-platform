using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerceApp.Application.DTOs
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(200, MinimumLength = 3,
            ErrorMessage = "El nombre debe tener entre 3 y 200 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(2000, MinimumLength = 10,
            ErrorMessage = "La descripción debe tener entre 10 y 2000 caracteres")]
        public string Description { get; set; } = string.Empty;

        [StringLength(500)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe estar entre 0.01 y 999999.99")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "CategoryId debe ser mayor a 0")]
        public int CategoryId { get; set; }

        public bool IsDigital { get; set; } = true;

        [StringLength(500)]
        public string? FileUrl { get; set; }

        public long? FileSize { get; set; }

        [StringLength(500)]
        public string? ThumbnailUrl { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
