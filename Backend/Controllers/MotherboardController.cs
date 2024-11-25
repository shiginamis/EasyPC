using System;
using Backend.Data;
using Backend.Dtos;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

public class MotherboardController(DataContext context) : BaseApiController
{
       [HttpGet("all")]
      public async Task<ActionResult<IEnumerable<Motherboard>>> GetMotherBoards()
    {
        var Motherboards = await context.Motherboards.ToListAsync();
        if(Motherboards.Count() == 0) return NotFound("No Motherboards found");
        return Motherboards;
    }

[HttpPost("register")]
 public async Task<ActionResult<Motherboard>> Register(MotherBoardDto motherBoardDto)
    {

        if (await Exists(motherBoardDto.Name))
        {
            return BadRequest("Name is taken");
        }

        if (motherBoardDto == null) return BadRequest("Empty data");

        var motherBoard = new Motherboard
        {
            Name = motherBoardDto.Name,
            Socket = motherBoardDto.Socket
        };

        if (motherBoard.Name.Length < 3 )
            return BadRequest("Name too short");

        else if(motherBoard.Socket.Length < 3)
            return BadRequest("Socket name too short");

        context.Motherboards.Add(motherBoard);

        await context.SaveChangesAsync();

        return motherBoard;
    }


    private async Task<bool> Exists(string productName)
    {
        return await context.Motherboards.AnyAsync(x => x.Name.ToLower() == productName.ToLower());
    }
 
}
