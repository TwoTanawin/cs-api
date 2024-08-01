using Microsoft.AspNetCore.Mvc;
using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using System;


namespace Breakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastControllers : ControllerBase
{
    [HttpPost()]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet);
        
        var response = new BreakfastResponse(
                                      breakfast.Id,
                                      breakfast.Name,
                                      breakfast.Description,
                                      breakfast.StartDateTime,
                                      breakfast.EndDateTime,
                                      breakfast.LastModifiedDateTime,
                                      breakfast.UtcNow,
                                      breakfast.Sweet);

        return CreatedAtAction(
            actionName : nameof(GetBreakfast),
            routeValues : new {id = breakfast.id},
            value : response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpserBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        return Ok(id);
    }
}