using System;
using Backend.Data;

namespace Backend.Models;

public class Products(DataContext context)
{
    List<Processor> Processors;
    List<Motherboard> Motherboards;
    List<Graphics_Card> Graphics_Card;
    List<PSU> PSUs;
    List<RAM> RAMs;
    List<Case> Cases;
}
