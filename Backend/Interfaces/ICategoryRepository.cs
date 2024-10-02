using Backend.Models;

namespace Backend.Interfaces;

public interface ICategoryRepository
{
    ICollection<Category> GetCategories();
    Category GetCategoryById(int id);
    void AddCategory(Category category);
}