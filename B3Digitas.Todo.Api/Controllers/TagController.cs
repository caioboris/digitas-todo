using B3Digitas.Todo.Api.DTOs;
using B3Digitas.Todo.Api.Mappers;
using B3Digitas.Todo.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace B3Digitas.Todo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _tagService.GetAllAsync();
        
        if (result.IsSucces)
        {
            return Ok(result.ResultBody);
        }

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _tagService.GetAsync(id);

        if (result.IsSucces)
        {
            if(result.ResultBody == null)
            {
                return NotFound();
            }
            
            return Ok(result.ResultBody);
        }

        return BadRequest();
    }

    [HttpGet("title/{title}")]
    public async Task<IActionResult> GetByTitle(string title)
    {
        var result = await _tagService.GetByTitleAsync(title);

        if (result.IsSucces)
        {
            if(result.ResultBody == null)
            {
                return NotFound();
            }

            return Ok(result.ResultBody);
        }

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Create(TagDTO tagDto)
    {
        var result = await _tagService.CreateAsync(tagDto.ToEntity());
        if (result.IsSucces)
        {
            return Ok(result.ResultBody);
        }

        return BadRequest();
    }
}
