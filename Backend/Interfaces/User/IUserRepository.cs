using Backend.Interfaces.Generic.Repository;
using Backend.Models;

namespace Backend.Interfaces;

public interface IUserRepository: IGenericRepository<User>
{
    Task<bool> UsernameExists(string username);
    Task<User> GetByUsername(string username);
}