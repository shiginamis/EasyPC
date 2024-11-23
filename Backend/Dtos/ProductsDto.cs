using System;
using Backend.Models;

namespace Backend.Dtos;

public class ProductsDto
{
    List<Processor> Processors;
    List<Motherboard> Motherboards;
    List<Graphics_Card> Graphics_Card;
    List<PSU> PSUs;
    List<RAM> RAMs;
    List<Case> Cases;
}
