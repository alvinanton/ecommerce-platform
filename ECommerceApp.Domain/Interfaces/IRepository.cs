using ECommerceApp.Domain.Common;
using System.Linq.Expressions;

namespace ECommerceApp.Domain.Interfaces
{

    /// <summary>
    /// Generic repository interface for CRUD operations
    /// </summary>
    /// <typeparam name="T">Entity type that inherits from BaseEntity</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get a single entity by ID
        /// </summary>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Get all entities
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Find entities matching a predicate (filter)
        /// </summary>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Add a new entity
        /// </summary>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Update an existing entity
        /// </summary>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Delete an entity
        /// </summary>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Commit all changes to the database
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}