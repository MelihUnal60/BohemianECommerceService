using webapi.Entities;

public class DapperRepository<T> : IRepository<T> where T : BaseEntity
{
    public T Add(T entity)
    {
        throw new NotImplementedException();
    }

    public T Get(int id)
    {
        throw new NotImplementedException();
    }

    public T GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public T GetByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public bool Remove(int id)
    {
        throw new NotImplementedException();
    }

    public T Update(int id, T entity)
    {
        throw new NotImplementedException();
    }
}
