using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class User
{
    public required int Id { get; set; }
    public required string Username { get; set; }
    public required string  Password { get; set; }
}
