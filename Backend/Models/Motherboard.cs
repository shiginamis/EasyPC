using System;

namespace Backend.Models;

public class Motherboard
{
    public int Id { get; set; }
    public required string Socket { get; set; }
    public required string Model { get; set; }
    public required bool SupportsOverclocking { get; set; } 
    
}
