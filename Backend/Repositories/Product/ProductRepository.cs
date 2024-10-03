using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Backend.Models.Filter;
using Backend.Repositories.Generic;

namespace Backend.Repositories;

public class ProductRepository: GenericRepository<Product>, IProductRepository
{
    public ProductRepository(DataContext context, ILogger<GenericRepository<Product>> logger)
        : base(context, logger)
    {
    }

    public ICollection<Product> GetFilteredProducts(ProductFilter filter)
    {
        IQueryable<Product> query = _context.Products.AsQueryable();

        if(filter.MinStock.HasValue)
        {
            query = query.Where(p => p.Stock >= filter.MinStock.Value);
        }

        if(filter.MaxStock.HasValue)
        {
            query = query.Where(p => p.Stock <= filter.MaxStock.Value);
        }
        
        if(filter.MinPrice.HasValue)
        {
            query = query.Where(p => p.Price >= filter.MinPrice.Value);
        }

        if(filter.MaxPrice.HasValue)
        {
            query = query.Where(p => p.Price <= filter.MaxPrice.Value);
        }

        if (!string.IsNullOrEmpty(filter.Category))
        {
            query = query.Where(p => p.Category.Name == filter.Category);
        }
        
        return query.ToList();
    }
}