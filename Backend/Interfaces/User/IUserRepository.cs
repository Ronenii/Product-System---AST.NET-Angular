using Backend.Models;

namespace Backend.Interfaces;

public interface IUserRepository
{
    Task<bool> UsernameExists(string username);
    Task<bool> EmailExists(string username);
}