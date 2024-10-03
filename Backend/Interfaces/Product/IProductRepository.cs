using Backend.Models;
using Backend.Models.Filter;

namespace Backend.Interfaces;

public interface IProductRepository
{
    ICollection<Product> GetFilteredProducts(ProductFilter filter);
}