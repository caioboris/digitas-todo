using B3Digitas.Todo.Api.DTOs;

namespace B3Digitas.Todo.Api.Mappers;

public static class TodoMapper
{
    public static TodoDTO ToDTO(this Domain.Entities.Todo todo)
    {
        return new TodoDTO
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            TagColor = todo.Tag.Color,
            TagName = todo.Tag.Name,
            CreatedAt = todo.CreatedAt,
            EndsAt = todo.EndsAt
        };
    }

    public static Domain.Entities.Todo ToEntity(this TodoDTO todoDto)
    {
        return new Domain.Entities.Todo
        {
            Id = todoDto.Id,
            Title = todoDto.Title,
            Description = todoDto.Description,
            CreatedAt = todoDto.CreatedAt,
            EndsAt = todoDto.EndsAt,
            Status = todoDto.Status,
            Tag = new Domain.Entities.Tag
            {
                Name = todoDto.TagName,
                Color = todoDto.TagColor
            }
        };
    }
}
