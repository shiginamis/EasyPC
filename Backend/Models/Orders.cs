using System;

namespace Backend.Models;

public class Orders
{
    public int Id { get; set; }
    public required int UserId { get; set; } 
    public  DateTime OrderDate { get; set; } // Datum narudžbe
    public string ShippingAddress { get; set; } // Adresa za dostavu
    public decimal TotalPrice { get; set; } // Ukupna cena narudžbe
    public string OrderStatus { get; set; } // Status narudžbe (npr. "Na čekanju", "Poslato")
    public decimal? Discounts { get; set; } // Iznos popusta (ako postoji)
}
