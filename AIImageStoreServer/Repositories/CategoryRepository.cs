using AIImageStoreServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AIImageStoreServer.Repositories
{
    public interface ICategoryRepository
    {
        Task<bool> AddCategory(Category category);
        Task<bool> DeleteCategory(Category category);
        Task<Category> EditCategory(Category category);
    }
    public class CategoryRepository
        : ICategoryRepository
    {
        AiImageStoreContext _context;
        public CategoryRepository(AiImageStoreContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCategory(Category category)
        {
            try
            {
                var newCategory = await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();

                return true;
                

            }catch (Exception ex) {
                return false;
            }
        }

        public async Task<bool> DeleteCategory(Category category)
        {
            try
            {
                var categoryForRemoval = await _context.Categories.FindAsync(category.CategoryId);
                if (categoryForRemoval != null)
                {
                    _context.Categories.Remove(categoryForRemoval);
                    await _context.SaveChangesAsync();

                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Category?> EditCategory(Category category)
        {
            try
            {
                var categoryForEdit = await _context.Categories.FindAsync(category.CategoryId);
                if (categoryForEdit != null)
                {
                    categoryForEdit = category;
                    await _context.SaveChangesAsync();


                    return categoryForEdit;
                }
                return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
