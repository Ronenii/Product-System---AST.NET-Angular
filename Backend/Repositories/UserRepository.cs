using Backend.Data;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Repositories;

public class UserRepository(DataContext context): IUserRepository
{
    private readonly DataContext _context = context;

    public ICollection<User> GetUsers()
    {
        return _context.Users.ToList();
    }

    public User GetUserById(int id)
    {
        return _context.Users.Find(id);
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
    }
}