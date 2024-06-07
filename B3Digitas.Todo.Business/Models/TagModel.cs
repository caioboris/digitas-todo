namespace B3Digitas.Todo.Business.Models;

public class TagModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;
}
