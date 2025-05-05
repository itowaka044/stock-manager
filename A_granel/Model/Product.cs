namespace A_granel;

public class Product
{
    public Product(string? name, DateOnly expDate, int pricePerGram, int quantity, string? type)
    {
        Name = name;
        ExpDate = expDate;
        PricePerGram = pricePerGram;
        Quantity = quantity;
        Type = type;
    }

    public int Id {get;set;}

    public string? Name { get;set;}

    public DateOnly ExpDate { get; set; }

    public int PricePerGram { get; set; }

    public int Quantity { get; set; }

    public string? Type {get;set;}
}
