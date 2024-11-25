using System;
using Backend.Data;
using Backend.Dtos;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

public class CaseController(DataContext context): BaseApiController
{
    [HttpGet("all")]
      public async Task<ActionResult<IEnumerable<Case>>> GetCases()
    {
        var Cases = await context.Cases.ToListAsync();
        if(Cases.Count() == 0) return NotFound("No cases found");
        return Cases;
    }

[HttpPost("register")]
 public async Task<ActionResult<Case>> Register(CaseDto caseDto)
    {

        if (await Exists(caseDto.Name))
        {
            return BadRequest("Name is taken");
        }

        if (caseDto == null) return BadRequest("Empty data");

        var Case = new Case
        {
            Name = caseDto.Name,
            Type = caseDto.Type
        };

        if (Case.Name.Length < 3 )
            return BadRequest("Name too short");

        else if(Case.Type.Length < 3)
            return BadRequest("Input not valid");

        context.Cases.Add(Case);

        await context.SaveChangesAsync();

        return Case;
    }


    private async Task<bool> Exists(string productName)
    {
        return await context.Cases.AnyAsync(x => x.Name.ToLower() == productName.ToLower());
    }
}
