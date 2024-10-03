using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Backend.Repositories.Generic;

namespace Backend.Repositories;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    public UserRepository(DataContext context, ILogger<GenericRepository<User>> logger)
        : base(context, logger)
    {
    }
    
    
}