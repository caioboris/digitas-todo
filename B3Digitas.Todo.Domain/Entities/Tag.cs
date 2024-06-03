using System.ComponentModel.DataAnnotations;

namespace B3Digitas.Todo.Domain.Entities;

public class Tag
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;

    [Required, MaxLength(7)]
    public string Color { get; set; } = "#00FF00";
}