using A_granel.Model;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace A_granel.Services;

public class ProductService
{
    private readonly AppDbContext DbContext;

    public ProductService(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<Product> CreateProductAsync(ProductCreateDTO product)
    {
        Product newProduct = new Product(product.Name, product.ExpDate, product.PricePer100G, product.Quantity);

        DbContext.ProductTable.Add(newProduct);

        try
        {
            await DbContext.SaveChangesAsync();
            return newProduct;
        }
        catch (Exception exception)
        {
            throw new Exception("erro ao salvar no banco", exception);
        }

    }

    public async Task<IEnumerable<Product>> ReadAllAsync()
    {

        try
        {
            IEnumerable<Product> products = await DbContext.ProductTable.ToListAsync();
            return products;
        }
        catch (Exception exception)
        {
            throw new Exception("erro ao ler banco", exception);
        }
    }


    public async Task<Product> ReadProductByIdAsync(int id)
    {
        try
        {
            Product product = await DbContext.ProductTable.FindAsync(id);

            return product;
        }
        catch (Exception exception)
        {
            throw new Exception("produto não existe", exception);
        }

    }

    public async Task<Product> UpdateProductAsync(int id, ProductCreateDTO productDTO)
    {

        Product newProduct = await DbContext.ProductTable.FindAsync(id);

        if (newProduct == null)
        {
            throw new Exception("Produto não encontrado");
        }

        newProduct.Name = productDTO.Name;

        newProduct.ExpDate = productDTO.ExpDate;

        newProduct.PricePer100G = productDTO.PricePer100G;

        newProduct.Quantity = productDTO.Quantity;

        DbContext.ProductTable.Update(newProduct);

        try
        {
            await DbContext.SaveChangesAsync();
            return newProduct;
        }
        catch (Exception exception)
        {
            throw new Exception("erro ao atualizar o produto", exception);
        }

    }


    public async Task<Product> DeleteProductAsync(int id)
    {

        try
        {

            Product product = await DbContext.ProductTable.FindAsync(id);

            if (product == null)
            {
                Console.WriteLine("produto não encontrado");
            }

            DbContext.ProductTable.Remove(product);

            await DbContext.SaveChangesAsync();


            return product;

        }
        catch (Exception exception)
        {

            throw new Exception("erro", exception);

        }

    }

    public async Task<Product> ChangeQuantityAsync(int id, int quantity)
    {
        try
        {
            Product updatedProduct = await DbContext.ProductTable.FindAsync(id);

            updatedProduct.Quantity = quantity;

            DbContext.ProductTable.Update(updatedProduct);

            await DbContext.SaveChangesAsync();

            return updatedProduct;

        }
        catch (Exception exception)
        {
            throw new Exception("pintinho 2cm", exception);
        }
    }

}