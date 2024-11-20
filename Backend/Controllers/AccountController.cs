using System;
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

        if (await UserExists(registerDto.Username))
        {
            return BadRequest("Username is taken");
        }

        if (registerDto == null) return BadRequest("User data is null");

        var user = new User
        {
            Username = registerDto.Username.ToLower(),
            Password = registerDto.Password
        };

        if (user.Username.Length < 3 )
            return BadRequest("Username too short");

        else if(user.Password.Length < 8)
            return BadRequest("Password too short");

        context.Users.Add(user);

        await context.SaveChangesAsync();

        return user;
    }


    private async Task<bool> UserExists(string username)
    {
        return await context.Users.AnyAsync(x => x.Username.ToLower() == username.ToLower());
    }

}
