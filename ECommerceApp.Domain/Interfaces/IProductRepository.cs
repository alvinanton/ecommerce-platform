using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceApp.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetActiveProductsAsync();
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
    }
}
