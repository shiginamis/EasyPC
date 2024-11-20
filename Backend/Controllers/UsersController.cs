using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Backend.Data;
using Backend.Dtos;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.ObjectPool;

namespace Backend.Controllers;

public class UsersController(DataContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();
        if(!users.Any()) return NotFound("No users found");
        return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return NotFound("No user with this ID");
        return user;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<User>> DeleteUser(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return NotFound("No user with this ID");
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return user;
    }

    [HttpDelete("all")]
    public async Task<ActionResult<User>> DeleteAllUsers()
    {
        var users = await context.Users.ToListAsync();
        if(!users.Any()) return NotFound("No users found");
        context.RemoveRange(users);
        await context.SaveChangesAsync();
        return Ok("Done");
    }


    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(int id, UserDto userDto)
    {

        var user = await context.Users.FindAsync(id);
        if (user == null) return NotFound("No user with this ID");
        user.Username = userDto.Username ?? user.Username;
        user.Password = userDto.Password ?? user.Password;
        await context.SaveChangesAsync();
        return Ok();
    }

}
