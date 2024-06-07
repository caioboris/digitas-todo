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
        
        if (result.IsSuccess)
        {
            return Ok(result.ResponseBody);
        }

        return BadRequest(result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _tagService.GetAsync(id);

        if (result.IsSuccess)
        {
            if(result.ResponseBody == null)
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
        var result = await _tagService.GetByTitleAsync(title);

        if (result.IsSuccess)
        {
            if(result.ResponseBody == null)
            {
                return NotFound();
            }

            return Ok(result.ResponseBody);
        }

        return BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TagDTO tagDto)
    {
        var result = await _tagService.CreateAsync(tagDto.ToModel());
        var responseBody = result.ResponseBody;

        if (result.IsSuccess && responseBody != null)
        {
            var location = Request.GetEncodedUrl() + $"/{responseBody.Id}";
            return Created(location, responseBody);
        }

        return BadRequest(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id,[FromBody]TagDTO tagDTO)
    {
        var result = await _tagService.UpdateAsync(id,tagDTO.ToModel());

        if (result.IsSuccess)
        {
            return Ok(result.ResponseBody);
        }

        return BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _tagService.DeleteAsync(id);
        if (result.IsSuccess)
        {
            return Ok(result.Message);
        }

        return BadRequest(result);
    }
}
