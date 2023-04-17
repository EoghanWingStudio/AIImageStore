using AIImageStoreServer.Models;
using AIImageStoreServer.Repositories;

namespace AIImageStoreServer.Services
{
    public interface IImageStoreService
    {
        Task<bool> CreateCategory(Category category);
        Task<bool> DeleteCategory(Category category);
        Task<Category?> UpdateCategory(Category category);
    }
    public class CategoryService : IImageStoreService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> CreateCategory(Category category)
        {
            var newCategory = await _categoryRepository.AddCategory(category);

            if (newCategory)
                return true;
            return false;
        }

        public async Task<bool> DeleteCategory(Category category)
        {
            var categoryDeleted = await _categoryRepository.DeleteCategory(category);

            if(categoryDeleted) 
                return true;
            return false;
        }

        public async Task<Category?> UpdateCategory(Category category)
        {
            var categoryUpdated = await _categoryRepository.EditCategory(category);

            if(categoryUpdated != null) 
                return categoryUpdated;
            return null;
        }
    }
}
