using System;

namespace Backend.Models;

public class Case
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
}
