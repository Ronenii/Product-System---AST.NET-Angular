using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Backend.Models.Filter;

namespace Backend.Repositories;

public class ProductRepository(DataContext i_Context) : IProductRepository
{
    private readonly DataContext _context = i_Context;

    public ICollection<Product> GetProducts()
    {
        return _context.Products.ToList();
    }

    public Product GetProductById(int id)
    {
        return _context.Products.Find(id);
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

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
    }

    public void DeleteProduct(int id)
    {
        Product productToDelete = _context.Products.Find(id);
        if(productToDelete != null)
        {
            _context.Products.Remove(productToDelete);
        }
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }
}