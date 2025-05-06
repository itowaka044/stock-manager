using A_granel.Model;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace A_granel.Services;

public class ProductService
{
    private readonly AppDbContext DbContext;

    public ProductService(AppDbContext dbContext){
        DbContext = dbContext;
    }

    public async Task<Product> CreateProductAsync(ProductCreateDTO product){
        Product newProduct = new Product(product.Name, product.ExpDate, product.PricePerGram, product.Quantity, product.Type);
        
        DbContext.ProductTable.Add(newProduct);

        try{
            await DbContext.SaveChangesAsync();
            return newProduct;
        }catch(Exception exception){
            throw new Exception("erro ao salvar no banco", exception);
        }
        
    } 

    public async Task<IEnumerable<Product>> ReadAllAsync(){

        try{        
            IEnumerable<Product> products = await DbContext.ProductTable.ToListAsync();

            return products;
        }catch(Exception exception){
            throw new Exception("Erro ao ler banco", exception);
        }
    }

}
