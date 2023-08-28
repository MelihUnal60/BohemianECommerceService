namespace webapi.Entities;

public sealed class Product:BaseEntity
{
    public string ProductTitle { get; set; }

    public decimal ProductPrice { get; set; }

    public string ProductDescription { get; set; }

    public string Category { get; set; }

    public string ProductPhoto { get; set; }

    public int Stock { get; set; }

    public decimal ProductRating { get; set; }

    public int ProductRateCount { get; set; }
}
