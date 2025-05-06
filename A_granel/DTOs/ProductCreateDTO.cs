using System;

namespace A_granel.Model;

public class ProductCreateDTO
{
    public string? Name { get;set;}

    public DateOnly ExpDate { get; set; }

    public int PricePerGram { get; set; }

    public int Quantity { get; set; }


    public ProductCreateDTO(string? name, DateOnly expDate, int pricePerGram, int quantity)
    {
        Name = name;
        ExpDate = expDate;
        PricePerGram = pricePerGram;
        Quantity = quantity;
    }

}
