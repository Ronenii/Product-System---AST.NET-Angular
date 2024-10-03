namespace Backend.Interfaces.Generic.Repository;

public interface IGenericRepository<T> where T: class
{
    ICollection<T> All();
    T GetById(int id);
    bool Add(T entity);
    bool Delete(int id);
    bool Update(T entity);
    bool SaveChanges();
}