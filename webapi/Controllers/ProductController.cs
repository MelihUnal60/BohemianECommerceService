using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using webapi.Entities;


[ApiController]
[Route("[controller]")]

public class ProductController : ControllerBase
{
    private readonly IProductService _productService;


    public ProductController(IProductService productService)
    {
        _productService = productService;

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        var result = await _productService.GetAllProducts();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var result = await _productService.Get(id);
        if (result != null)
            return Ok(result);
        else
            return NotFound();
    }

    [HttpGet("{category}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string category)
    {
        var result = await _productService.GetProductsByCategory(category);
        if (result != null)
            return Ok(result);
        else
            return NotFound();
    }


    [HttpGet("{title}")]
    public async Task<ActionResult<Product>> GetByTitle(string title)
    {
        var result = await (_productService.GetByTitle(title));
        if (result != null)
            return Ok(result);
        else
            return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Product>> AddProduct(Product product)
    {
        await _productService.Add(product);
        return Ok();
    }

    [HttpPut]

    public async Task<ActionResult<Product>> UpdateProduct(int id,  Product product)
    {
        var result  = await _productService.Get(id);
        if (result != null)
        {
            await _productService.Update(id, product);
            return Ok();
        }
        else
            return NotFound();  
    }

    [HttpDelete("{id}")]

    public async Task<ActionResult<Product>> DeleteProduct(int id)
    {
        var result = await _productService.Get(id);
        if (result != null)
        {
            await _productService.Remove(id);
            return Ok();
        }
        else
            return NotFound();
    }

}
