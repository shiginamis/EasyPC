using System;
using System.Security.Cryptography;
using System.Text;
using Azure;
using Backend.Data;
using Backend.Dtos;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

public class AccountController(DataContext context) : BaseApiController
{

    [HttpPost("Register")]
    public async Task<ActionResult<User>> Register(RegisterDto registerDto)
    {
        if (registerDto == null) return BadRequest("User data empty");
        if (await Exists(registerDto.Username))
        {
            return BadRequest("Username is taken");
        }

        using var hmac = new HMACSHA512();

        var user = new User
        {
            Username = registerDto.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };

        if (user.Username.Length < 3)
            return BadRequest("Username too short");

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return user;
    }



    private async Task<bool> Exists(string username)
    {
        return await context.Users.AnyAsync(x => x.Username.ToLower() == username.ToLower());
    }

}
