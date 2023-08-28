

using Dapper;
using Npgsql;
using NpgsqlTypes;
using webapi.Entities;

public class ProductService : IProductService
{
    private const string CONNECTION_STRING = "Host=45.11.96.168:5432;" +
         "Username=postgres;" +
         "Password=Aa20012001;" +
         "Database=bohemian";

    private NpgsqlConnection connection;

    public ProductService()
    {
        connection = new NpgsqlConnection(CONNECTION_STRING);
    }

    public async Task Add(Product product)
    {
        try
        {
            connection.Open();

            // sql injection korumasý, her zaman parametre ile çalýþmak lazým
            string commandText = $"insert into products (producttitle, productprice, productdescription, category, productphoto, stock, productrating, productratecount) values (@producttitle, @productprice, @productdescription, @category, @productphoto, @stock, @productrating, @productratecount)";

            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                

                cmd.Parameters.AddWithValue("producttitle", product.ProductTitle);
                cmd.Parameters.AddWithValue("productprice", product.ProductPrice);
                cmd.Parameters.AddWithValue("productdescription", product.ProductDescription);
                cmd.Parameters.AddWithValue("category", product.Category);
                cmd.Parameters.AddWithValue("productphoto", product.ProductPhoto);
                cmd.Parameters.AddWithValue("stock", product.Stock);
                cmd.Parameters.AddWithValue("productrating", product.ProductRating);
                cmd.Parameters.AddWithValue("productratecount", product.ProductRateCount);

                await cmd.ExecuteNonQueryAsync();
            }
        }
        finally
        {
            connection.Close();
        }
    }

    public async Task<Product> Get(int id)
    {
        try
        {
            connection.Open();

            string commandText = $"SELECT * FROM products WHERE id = @id";

            var selectedByIdProduct = await connection.QuerySingleAsync<Product>(commandText, new { id = id });

            return selectedByIdProduct;
        }
        finally
        {
            connection?.Close();
        }
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        try
        {
            connection.Open();

            

            string commandText = $"SELECT * FROM products";
            var products = await connection.QueryAsync<Product>(commandText, new { });

            return products;
        }
        finally
        {
            connection.Close();
        }
    }

    public async Task<Product> GetByTitle(string title)
    {
        try
        {
            connection.Open();

            string commandText = $"SELECT * FROM products WHERE producttitle = @title";
            var selectedByTitleProduct = await connection.QuerySingleAsync<Product>(commandText, new { producttitle = title });
            return selectedByTitleProduct;
        }
        finally
        {
            connection.Close();
        }
    }

  

    public async Task Remove(int id)
    {
        try
        {
            connection.Open();

            string commandText = $"DELETE FROM products WHERE id = @id ";
            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.Remove("id");
                await cmd.ExecuteNonQueryAsync();
            }

        }
        finally
        {
            connection.Close();
        }
    }

    public async Task Update(int id, Product product)
    {
        try
        {
            connection.Open();

            var commandText = $"UPDATE products SET producttitle = @producttitle, productprice = @productprice, productdescription = @productdescription," +
                $"category = @category, productphoto = @productphoto, stock = @stock, productrating = @productrating, productratecount = @productratecount WHERE id = @id";
            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("producttitle", product.ProductTitle);
                cmd.Parameters.AddWithValue("productprice", product.ProductPrice);
                cmd.Parameters.AddWithValue("pproductdescription", product.ProductDescription);
                cmd.Parameters.AddWithValue("category", product.Category);
                cmd.Parameters.AddWithValue("productphoto", product.ProductPhoto);
                cmd.Parameters.AddWithValue("stock", product.Stock);
                cmd.Parameters.AddWithValue("productrating", product.ProductRating);
                cmd.Parameters.AddWithValue("prouctratecount", product.ProductRateCount);

                await cmd.ExecuteNonQueryAsync();
            }
        }
        finally
        {
            connection.Close();
        }
    }
}