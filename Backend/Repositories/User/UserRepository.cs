using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Backend.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    public UserRepository(DataContext context, ILogger<GenericRepository<User>> logger)
        : base(context, logger)
    {
    }

    public Task<bool> UsernameExists(string username)
    {
        return _context.Users.AnyAsync(u => u.Username == username);
    }

    public Task<User> GetByUsername(string username)
    {
        return _context.Users.SingleOrDefaultAsync(u => u.Username == username);
    }
}