using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace B3Digitas.Todo.Data.Entities;

public class Tag
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [Required]
    public Color Color { get; set; }
}