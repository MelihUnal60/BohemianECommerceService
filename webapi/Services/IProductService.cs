

using webapi.Entities;

public interface IProductService
{
    Task Add(Product product);

    Task Remove(int id);

    Task <Product> Get(int id);

    Task<Product> GetByTitle(string title);

    Task Update(int id, Product product);

    Task<IEnumerable<Product>> GetAllProducts();

}