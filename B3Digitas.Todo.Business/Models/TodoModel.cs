using B3Digitas.Todo.Domain.Entities.Enums;

namespace B3Digitas.Todo.Business.Models;

public class TodoModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime EndsAt { get; set;}

    public TodoStatus Status { get; set; }

    public TagModel Tag { get; set; }

    public bool IsLate { get; set; }

}
