using System;
using Backend.Data;
using Backend.Dtos;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

public class PSUController(DataContext context) : BaseApiController
{
       [HttpGet("all")]
      public async Task<ActionResult<IEnumerable<PSU>>> GetPSU()
    {
        var PSUs= await context.PSUs.ToListAsync();
        if(PSUs.Count() == 0) return NotFound("No PSU found");
        return PSUs;
    }

[HttpPost("register")]
 public async Task<ActionResult<PSU>> Register(PsuDto psuDto)
    {

        if (await Exists(psuDto.Name))
        {
            return BadRequest("Name is taken");
        }

        if (psuDto == null) return BadRequest("Empty data");

        var PSU = new PSU
        {
            Name = psuDto.Name,
            Power = psuDto.Power
        };

        if (PSU.Name.Length < 3 )
            return BadRequest("Name too short");

        else if(PSU.Power.Length < 3)
            return BadRequest("Power not valid");

        context.PSUs.Add(PSU);

        await context.SaveChangesAsync();

        return PSU;
    }


    private async Task<bool> Exists(string productName)
    {
        return await context.PSUs.AnyAsync(x => x.Name.ToLower() == productName.ToLower());
    }
 
}
