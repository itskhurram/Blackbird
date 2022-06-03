using Blackbird.Application.Interfaces;
using Blackbird.Domain.Entities;
using Blackbird.Domain.Interfaces;

namespace Blackbird.Application.Services {
    public class CategoryService : ICategoryService {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }
        public async Task<IList<Category>> GetAllCategories(bool? isActive = null) {
            return await _categoryRepository.GetAllCategories(isActive);
        }
    }
}
