using System;

namespace Backend.Dtos;

public class AdminDto
{
    public  int Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}
