using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetActiveCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound();
            
            return Ok(category);
        }

        [HttpGet("{id:int}/subcategories")]
        public async Task<IActionResult> GetSubCategories(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            var subcategories = await _categoryRepository.GetSubCategoriesAsync(id);
            return Ok(subcategories);
        }
    }
}
