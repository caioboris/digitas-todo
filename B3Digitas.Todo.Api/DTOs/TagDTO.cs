using System.Text.Json.Serialization;

namespace B3Digitas.Todo.Api.DTOs;

public record TagDTO
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Color { get; set; } = "#00FF00";

}
