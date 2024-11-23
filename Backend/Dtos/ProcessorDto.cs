using System;

namespace Backend.Dtos;

public class ProcessorDto
{
    public int Id { get; set; }
    public  string Name { get; set; }
    public  string Socket { get; set; }
    public  int Price { get; set; } 
    public  bool StockAvailability { get; set; } 
    public  string? Model { get; set; } 
    public  int CoreCount { get; set; }
    public  int ThreadCount { get; set; }
}
