using Backend.Interfaces.Generic.Repository;
using Backend.Models;
using Backend.Models.Filter;

namespace Backend.Interfaces;

public interface IProductRepository: IGenericRepository<Product>
{
    Task<ICollection<Product>> GetFilteredProducts(ProductFilterDTO filterDto);

    Task<bool> NameExists(string name);
}