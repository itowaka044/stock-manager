using System;

namespace A_granel.DTOs;

public class ChangeQuantityDTO
{
    public int Quantity { get; set; }

    public ChangeQuantityDTO(int quantity)
    {
        Quantity = quantity;
    }
}
