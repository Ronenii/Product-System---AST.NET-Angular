using Backend.Models;
using Backend.Models.Filter;

namespace Backend.Interfaces;

public interface IProductRepository
{
    Task<ICollection<Product>> GetFilteredProducts(ProductFilter filter);
}