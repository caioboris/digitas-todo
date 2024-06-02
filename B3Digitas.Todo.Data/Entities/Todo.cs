using B3Digitas.Todo.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace B3Digitas.Todo.Data.Entities;

public class Todo
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt{ get; set; }
    public DateTime EndsAt{ get; set; }
    public TodoStatus Status { get; set; }
    public Tag Tag { get; set; } = new Tag();  
    
}
