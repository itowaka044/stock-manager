using System;

namespace A_granel.Model;

public class ProductCreateDTO
{
    public string? Name { get;set;}

    public DateOnly ExpDate { get; set; }

    public int PricePer100G { get; set; }

    public int Quantity { get; set; }


    public ProductCreateDTO(string? name, DateOnly expDate, int pricePer100G, int quantity)
    {
        Name = name;
        ExpDate = expDate;
        PricePer100G = pricePer100G;
        Quantity = quantity;
    }

}
