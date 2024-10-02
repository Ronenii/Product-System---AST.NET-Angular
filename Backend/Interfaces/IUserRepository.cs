using Backend.Models;

namespace Backend.Interfaces;

public interface IUserRepository
{
    ICollection<User> GetUsers();
    User GetUserById(int id);
    void AddUser(User user);
}