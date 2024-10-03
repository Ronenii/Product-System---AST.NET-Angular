using Backend.Data;
using Backend.Interfaces.Generic.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Generic;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
    protected DataContext _context;
    protected DbSet<T?> _dbSet;
    protected readonly ILogger _logger;

    protected GenericRepository(DataContext context, ILogger<GenericRepository<T>> logger)
    {
        _context = context;
        _logger = logger;
        this._dbSet = context.Set<T>();
    }

    public async Task<ICollection<T>> All()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<bool> Add(T? entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            _logger.LogInformation($"Added Entity: {entity}");
            return await SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding entity");
            return false;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            T? entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                _logger.LogWarning($"Entity with id {id} was not found.");
                return false;
            }

            _dbSet.Remove(entity);
            _logger.LogInformation($"Deleted Entity: {entity}");
            return await SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting entity");
            return false;
        }
    }

    public async Task<bool> Update(T? entity)
    {
        try
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _logger.LogInformation($"Updated Entity: {entity}");
            return await SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating entity");
            return false;
        }
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}