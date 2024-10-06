using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Backend.Models.Filter;
using Backend.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class ProductRepository: GenericRepository<Product>, IProductRepository
{
    public ProductRepository(DataContext context, ILogger<GenericRepository<Product>> logger)
        : base(context, logger)
    {
    }

    /*
     * LINQ usage
     * Returns a list of filtered products based on the given product filterDTO.
     * Since all filters are optional, this goes over each filter and if it exists,
     * adds the relevant query.
     */
    public async Task<ICollection<Product>> GetFilteredProducts(ProductFilterDTO filterDto)
    {
        IQueryable<Product> query = _context.Products.AsQueryable();

        if(filterDto.MinStock.HasValue)
        {
            query = query.Where(p => p.Stock >= filterDto.MinStock.Value);
        }

        if(filterDto.MaxStock.HasValue)
        {
            query = query.Where(p => p.Stock <= filterDto.MaxStock.Value);
        }
        
        if(filterDto.MinPrice.HasValue)
        {
            query = query.Where(p => p.Price >= filterDto.MinPrice.Value);
        }

        if(filterDto.MaxPrice.HasValue)
        {
            query = query.Where(p => p.Price <= filterDto.MaxPrice.Value);
        }

        if (filterDto.CategoryId.HasValue && filterDto.CategoryId.Value != 0)
        {
            query = query.Where(p => p.Category.Id == filterDto.CategoryId);
        }
        
        return await query.ToListAsync();
    }

    public Task<bool> NameExists(string name)
    {
        return _context.Products.AnyAsync(p => p.Name == name);
    }
}