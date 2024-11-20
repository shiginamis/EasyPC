using System;

namespace Backend.Models;

public class Processor
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Socket { get; set; }
}
