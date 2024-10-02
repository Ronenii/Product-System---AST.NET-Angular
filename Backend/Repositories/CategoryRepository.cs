using Backend.Data;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Repositories;

public class CategoryRepository(DataContext context): ICategoryRepository
{
    public readonly DataContext _context = context;

    public ICollection<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public Category GetCategoryById(int id)
    {
        return _context.Categories.Find(id);
    }

    public void AddCategory(Category category)
    {
        _context.Categories.Add(category);
    }
}