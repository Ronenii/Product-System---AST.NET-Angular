using Backend.Models;

namespace Backend.Interfaces;

public interface ICategoryRepository
{
    Task<bool> NameExists(string name);
}