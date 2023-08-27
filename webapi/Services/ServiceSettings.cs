using webapi.Entities;


public class ServiceSettings
{
    public static void RegisterServices()
    {
        IOCContainer.Register<IRepository<Product>>(() => new DapperRepository<Product>());
        IOCContainer.Register<IProductService>(() => new ProductService());
    }
}

