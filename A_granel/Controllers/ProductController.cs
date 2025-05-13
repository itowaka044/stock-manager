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

    public ProductController(ProductService service){
        Service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> ReadAllAsync(){
        
        IEnumerable<Product> products = await Service.ReadAllAsync();
        return Ok(products);
       
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProductAsync(ProductCreateDTO product){

        Product newProduct = await Service.CreateProductAsync(product);
        return Ok(newProduct);
        
    }
    // [HttpPut]
    // public async Task<ActionResult<Product>> UpdateProductAsync(){

    //     Product updatedProduct = await Service.UpdateProductAsync(product);
    //     return Ok(updatedProduct);
    // }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProductAsync(int id){

        Product removedProduct = await Service.DeleteProductAsync(id);

        return Ok(removedProduct);
    }

}
