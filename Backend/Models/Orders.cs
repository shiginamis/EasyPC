using System;

namespace Backend.Models;

public class Orders
{
    public int Id { get; set; }
    public  int UserId { get; set; } 
    public  DateTime OrderDate { get; set; } // Datum narudžbe
    public string ShippingAddress { get; set; } // Adresa za dostavu
    public int TotalPrice { get; set; } // Ukupna cena narudžbe
    public string OrderStatus { get; set; } // Status narudžbe (npr. "Na čekanju", "Poslato")
    public int? Discounts { get; set; } // Iznos popusta (ako postoji)
}
