using System;

namespace Backend.Dtos;

public class UserDto
{
    public required int Id { get; set; }
    public required string Username { get; set; }
    public required string  Password { get; set; }
}
