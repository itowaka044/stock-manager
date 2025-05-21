using A_granel.Model;
using A_granel.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A_granel.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService Service;

    public ProductController(ProductService service) {
        Service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> ReadAllAsync() {

        IEnumerable<Product> products = await Service.ReadAllAsync();
        return Ok(products);

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> ReadProductById(int id)
    {
        Product product = await Service.ReadProductByIdAsync(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProductAsync(ProductCreateDTO product) {

        Product newProduct = await Service.CreateProductAsync(product);
        return Ok(newProduct);

    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateProductAsync(int id, ProductCreateDTO product) {

        Product updatedProduct = await Service.UpdateProductAsync(id, product);
        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProductAsync(int id) {

        Product removedProduct = await Service.DeleteProductAsync(id);

        return Ok(removedProduct);
    }



     [HttpPut("{id}")]
     public async Task<ActionResult<Product>> PatchProductAsync(int id, int quantity) {

        Response.Headers.Add("Change-Quantity", $"/Product/Quantity/{id}");

        Product updatedProduct = await Service.ChangeQuantityAsync(id, quantity);

        return Ok(updatedProduct);
     }
}