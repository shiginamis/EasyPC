using System;

namespace Backend.Models;

public class Graphics_Card
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string VRAM { get; set; }
}
