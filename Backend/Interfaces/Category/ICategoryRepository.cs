using Backend.Interfaces.Generic.Repository;
using Backend.Models;

namespace Backend.Interfaces;

public interface ICategoryRepository: IGenericRepository<Category>
{
    Task<bool> NameExists(string name);
}