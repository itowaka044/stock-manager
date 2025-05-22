namespace A_granel;

public class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly ExpDate { get; set; }

    public int PricePer100G { get; set; }

    public int Quantity { get; set; }

    // Construtor para novos produtos (sem ID)
    public Product(string? name, DateOnly expDate, int pricePer100G, int quantity)
    {
        Name = name;
        ExpDate = expDate;
        PricePer100G = pricePer100G;
        Quantity = quantity;
    }
    
    // Construtor para produtos existentes (com ID)
    public Product(int id, string? name, DateOnly expDate, int pricePer100G, int quantity)
    {
        Id = id;
        Name = name;
        ExpDate = expDate;
        PricePer100G = pricePer100G;
        Quantity = quantity;
    }

}

