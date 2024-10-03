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

    public Task<bool> EmailExists(string email)
    {
        return _context.Users.AnyAsync(u => u.Email == email);
    }
}