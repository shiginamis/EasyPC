using System;
using Backend.Data;

namespace Backend.Models;

public class Products
{
    public int Id { get; set; }
    public List<Processor> Processors { get; set; }
    public List<Motherboard> Motherboards { get; set; }
    public List<Graphics_Card> Graphics_Card { get; set; }
    public List<PSU> PSUs { get; set; }
    public List<RAM> RAMs { get; set; }
    public List<Case> Cases { get; set; }

     public Products(DataContext context)
        {
            Processors = context.Processors.ToList();
            Motherboards = context.Motherboards.ToList();
            Graphics_Card = context.Graphics_Cards.ToList();
            PSUs = context.PSUs.ToList();
            RAMs = context.RAMs.ToList();
            Cases = context.Cases.ToList();
        }
}
