using A_granel.Model;
using A_granel.Services;
using Microsoft.AspNetCore.Mvc;

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
    [HttpPut]
    public async Task<ActionResult<Product>> UpdateProductAsync(){

        IEnumerable<Product> products = await Service.UpdateProductAsync(product);
        return Ok(product);
    }
        [HttpDelete]
    public async Task<ActionResult<Product>> DeleteProductAsync(){

        IEnumerable<Product> products = await Service.DeleteProductAsync(product);
        return Ok("Produto deletado com sucesso");
    }

}
