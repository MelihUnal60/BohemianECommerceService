using webapi.Entities;

public interface IRepository<T> where T : BaseEntity
{
    T Add(T entity);
    bool Remove(int id);
    T Get(int id);
    T Update(int id, T entity);
    T GetByTitle (string title);
    T GetAllProducts();
}