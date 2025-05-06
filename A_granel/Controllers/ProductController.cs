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

}
