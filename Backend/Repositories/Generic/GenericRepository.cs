using Backend.Data;
using Backend.Interfaces.Generic.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Generic;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
    protected DataContext _context;
    protected DbSet<T> dbSet;
    protected readonly ILogger _logger;

    public GenericRepository(DataContext context, ILogger<GenericRepository<T>> logger)
    {
        _context = context;
        _logger = logger;
        this.dbSet = context.Set<T>();
    }

    public ICollection<T> All()
    {
        return dbSet.ToList();
    }

    public T GetById(int id)
    {
        return dbSet.Find(id);
    }

    public bool Add(T entity)
    {
        bool isAdded = (dbSet.Remove(entity).State == EntityState.Deleted);

        if(isAdded)
        {
            _logger.LogInformation($"Added Entity: {entity}");
        }
        else
        {
            _logger.LogError("Error adding entity");
        }

        return isAdded;
    }

    public bool Delete(int id)
    {
        T entity = dbSet.Find(id);
        
        if(entity == null)
        {
            _logger.LogWarning($"Entity with id {id} was not found.");
            return false;
        }
        
        dbSet.Remove(entity);
        _logger.LogInformation($"Deleted Entity: {entity}");
        return true;
    }

    public bool Update(T entity)
    {
        try
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _logger.LogInformation($"Updated Entity: {entity}");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating entity");
            return false;
        }
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }
}