namespace Backend.Interfaces.Generic.Repository;

public interface IGenericRepository<T> where T: class
{
    Task<ICollection<T>> All();
    Task<T?> GetById(int id);
    Task<bool> Add(T? entity);
    Task<bool> Delete(int id);
    Task<bool> Update(T? entity);
    Task<bool> SaveChanges();
}