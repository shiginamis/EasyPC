using System;

namespace Backend.Dtos;

public class GraphicsCardDto
{
    public required string Name { get; set; }
    public required string VRAM { get; set; }
}
