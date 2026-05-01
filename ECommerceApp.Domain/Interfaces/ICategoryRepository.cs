using ECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetActiveCategoriesAsync();

        Task<IEnumerable<Category>> GetTopLevelCategoriesAsync();

        Task<IEnumerable<Category>> GetSubCategoriesAsync(int parentCategoryId);
    }
}
