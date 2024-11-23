using System;

namespace Backend.Models;

public class Processor
{
    public int Id { get; set; }
    public  string Name { get; set; }
    public  string Socket { get; set; }
    public  decimal Price { get; set; } 
    public  bool StockAvailability { get; set; } 
    public  string? Model { get; set; } 
    public  int CoreCount { get; set; }
    public  int ThreadCount { get; set; }
}
