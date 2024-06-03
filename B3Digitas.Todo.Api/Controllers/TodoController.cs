using B3Digitas.Todo.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace B3Digitas.Todo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{

    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var todos = await _todoService.GetAllAsync();
        return Ok();
    }

}
