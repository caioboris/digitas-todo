using B3Digitas.Todo.Api.DTOs;
using B3Digitas.Todo.Api.Mappers;
using B3Digitas.Todo.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace B3Digitas.Todo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService TodoService)
    {
        _todoService = TodoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _todoService.GetAllAsync();

        if (result.IsSuccess && result.ResponseBody != null)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _todoService.GetAsync(id);

        if (result.IsSuccess)
        {
            if (result.ResponseBody == null)
            {
                return NotFound();
            }

            return Ok(result.ResponseBody.ToDto());
        }

        return BadRequest(result);
    }

    [HttpGet("title/{title}")]
    public async Task<IActionResult> GetByTitle(string title)
    {
        var result = await _todoService.GetByTitleAsync(title);

        if (result.IsSuccess)
        {
            if (result.ResponseBody == null)
            {
                return NotFound();
            }

            return Ok(result.ResponseBody);
        }

        return BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TodoDTO TodoDto)
    {
        var result = await _todoService.CreateAsync(TodoDto.ToEntity());
        var responseBody = result.ResponseBody; 
        
        if (result.IsSuccess && responseBody != null)
        {
            var location = Request.GetEncodedUrl() + $"/{responseBody.Id}";
            return Created(location, responseBody);
        }

        return BadRequest(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id,[FromBody]TodoDTO todoDTO)
    {
        var result = await _todoService.UpdateAsync(id,todoDTO.ToEntity());

        if (result.IsSuccess)
        {
            return Ok(result.Message);
        }

        return BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _todoService.DeleteAsync(id);
        if (result.IsSuccess)
        {
            return Ok(result.Message);
        }

        return BadRequest(result);
    }
}
