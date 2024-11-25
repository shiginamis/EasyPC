using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class User
{
    public  int Id { get; set; }
    public required string Username { get; set; }
    public required byte[]  PasswordHash { get; set; }
    public required byte[]  PasswordSalt { get; set; }

}

