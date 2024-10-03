using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Backend.Repositories.Generic;

namespace Backend.Repositories;

public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DataContext context, ILogger<GenericRepository<Category>> logger)
        : base(context, logger)
    {
    }
}