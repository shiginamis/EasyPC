using System;
using Backend.Data;
using Backend.Dtos;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

public class RamController(DataContext context) : BaseApiController
{
       [HttpGet("all")]
      public async Task<ActionResult<IEnumerable<RAM>>> GetRAMs()
    {
        var RAMs = await context.RAMs.ToListAsync();
        if(RAMs.Count() == 0) return NotFound("No RAMs found");
        return RAMs;
    }

[HttpPost("register")]
 public async Task<ActionResult<RAM>> Register(RamDto ramDto)
    {

        if (await Exists(ramDto.Name))
        {
            return BadRequest("Name is taken");
        }

        if (ramDto == null) return BadRequest("Empty data");

        var ram = new RAM
        {
            Name = ramDto.Name,
            Type = ramDto.Type
        };

        if (ram.Name.Length < 3 )
            return BadRequest("Name too short");

        else if(ram.Type.Length < 3)
            return BadRequest("Type name too short");

        context.RAMs.Add(ram);

        await context.SaveChangesAsync();

        return ram;
    }


    private async Task<bool> Exists(string productName)
    {
        return await context.RAMs.AnyAsync(x => x.Name.ToLower() == productName.ToLower());
    }
 
}
