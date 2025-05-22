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

    public ProductController(ProductService service)
    {
        Service = service;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> ReadAllAsync()
    {
        IEnumerable<Product> products = await Service.ReadAllAsync();
        return Ok(products);
    }

    // mostra somente um produto pelo id
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> ReadProductById(int id)
    {
        Product product = await Service.ReadProductByIdAsync(id);
        return Ok(product);
    }

    // cria um novo produto, recebendo um ProductCreateDTO
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProductAsync(ProductCreateDTO product)
    {
        Product newProduct = await Service.CreateProductAsync(product);
        return Ok(newProduct);
    }

    // atualiza um produto existente, recebendo um ProductCreateDTO
    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateProductAsync(int id, ProductCreateDTO product)
    {
        Product updatedProduct = await Service.UpdateProductAsync(id, product);
        return Ok(updatedProduct);
    }

    // Deleta um produto pelo id
    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProductAsync(int id)
    {
        Product removedProduct = await Service.DeleteProductAsync(id);
        return Ok(removedProduct);
    }

    // Atualiza a quantidade de um produto, recebendo o id e a nova quantidade
    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> PatchProductAsync(int id, int quantity)
    {
        Response.Headers.Add("Change-Quantity", $"/Product/Quantity/{id}");

        Product updatedProduct = await Service.ChangeQuantityAsync(id, quantity);
        return Ok(updatedProduct);
    }
}