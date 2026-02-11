using ECommerceApp.Domain.Interfaces;
using ECommerceApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{

    /// <summary>
    /// Products API Controller - Handles product-related HTTP requests
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        ///<summary>
        ///Constructor - Repository is injected by ASP.NET Core's DI container
        ///</summary>
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        ///<summary>
        ///GET: api/products
        ///Get all active products
        ///</summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetActiveProductsAsync();

            return Ok(products);
        }

        /// <summary>
        /// Searches for products that match the specified search term and returns the results as an HTTP response.
        /// </summary>
        /// <param name="term">The search term used to filter products. Cannot be null or empty.</param>
        /// <returns>An <see cref="IActionResult"/> containing a collection of matching products if any are found; otherwise, a
        /// 404 Not Found response.</returns>
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return BadRequest(new { message = "Search term is required" });

            var products = await _productRepository.SearchProductsAsync(term);
            return Ok(products);
        }


        /// <summary>
        /// GET: api/products/5
        /// Get product by ID
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        /// <summary>
        /// Retrieves all products that belong to the specified category.
        /// </summary>
        /// <param name="categoryId">The unique identifier of the category for which to retrieve products. Must be a valid category ID.</param>
        /// <returns>An <see cref="IActionResult"/> containing the list of products in the specified category. Returns <seelangword="NotFound"/> if no products are found.</returns>
        [HttpGet("category/{categoryId:int}")]
        public async Task<IActionResult> GetByCategory (int categoryId)
        {
            var products = await _productRepository.GetByCategoryAsync(categoryId);
            if (products == null || !products.Any())
                return NotFound();
            return Ok(products);
        }       



    }
}
