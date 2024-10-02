using Backend.Models;
using Backend.Models.Filter;

namespace Backend.Interfaces;

public interface IProductRepository
{
    ICollection<Product> GetProducts();
    Product GetProductById(int id);
    ICollection<Product> GetFilteredProducts(ProductFilter filter);
    
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
    
    bool SaveChanges();
}