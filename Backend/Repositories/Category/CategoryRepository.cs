using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Backend.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DataContext context, ILogger<GenericRepository<Category>> logger)
        : base(context, logger)
    {
    }

    public Task<bool> NameExists(string name)
    {
        return _context.Categories.AnyAsync(c => c.Name == name);
    }
}