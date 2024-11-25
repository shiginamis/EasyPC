using System;

namespace Backend.Dtos;

public class MotherBoardDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public  string Socket { get; set; }
    public  string Model { get; set; }
    public  bool SupportsOverclocking { get; set; } 
}
