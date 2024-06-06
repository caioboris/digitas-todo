namespace B3Digitas.Todo.Api.DTOs;

public record TodoDTO
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string TagName { get; set; } = string.Empty;
    
    public DateTime EndsAt { get; set; }

    public string? Status { get; set; }
    
    public bool IsLate = false;
}
    