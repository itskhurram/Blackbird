using Blackbird.Application.Interfaces;
using Blackbird.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Blackbird.API.Controllers {
    public class CategoryController : BaseController {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> Get() {
            return await _categoryService.GetAllCategories(true);
        }
    }
}
