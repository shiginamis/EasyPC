using System;
using Backend.Data;
using Backend.Dtos;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

public class ProcessorController(DataContext context): BaseApiController
{
   [HttpGet("all")]
      public async Task<ActionResult<IEnumerable<Processor>>> GetProcessors()
    {
        var processors = await context.Processors.ToListAsync();
        if(processors.Count() == 0) return NotFound("No processors found");
        return processors;
    }

[HttpPost("register")]
 public async Task<ActionResult<Processor>> Register(ProcessorDto processorDto)
    {

        if (await ProcessorExists(processorDto.Name))
        {
            return BadRequest("Name is taken");
        }

        if (processorDto == null) return BadRequest("Empty data");

        var processor = new Processor
        {
            Name = processorDto.Name,
            Socket = processorDto.Socket
        };

        if (processor.Name.Length < 3 )
            return BadRequest("Name too short");

        else if(processor.Socket.Length < 3)
            return BadRequest("Socket name too short");

        context.Processors.Add(processor);

        await context.SaveChangesAsync();

        return processor;
    }


    private async Task<bool> ProcessorExists(string productName)
    {
        return await context.Processors.AnyAsync(x => x.Name.ToLower() == productName.ToLower());
    }
 
}
