using B3Digitas.Todo.Domain.Entities.Enums;

namespace B3Digitas.Todo.Api.DTOs;

public record TodoDTO
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime EndsAt { get; set; }

    public string TagName { get; set; } = string.Empty;

    public string TagColor { get; set; } = string.Empty;

    public TodoStatus Status { get; set; }
}
    