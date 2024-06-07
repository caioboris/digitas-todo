using B3Digitas.Todo.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace B3Digitas.Todo.Domain.Entities;

public class Todo
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    public DateTime CreatedAt{ get; set; } = DateTime.UtcNow;
    
    public DateTime EndsAt{ get; set; }

    public bool IsLate => DateTime.UtcNow > EndsAt;
    
    public TodoStatus Status { get; set; }

    [JsonIgnore]
    public Tag? Tag { get; set; }
    
}
