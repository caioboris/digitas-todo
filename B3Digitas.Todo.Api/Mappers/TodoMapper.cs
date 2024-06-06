using B3Digitas.Todo.Api.DTOs;
using B3Digitas.Todo.Domain.Entities.Enums;

namespace B3Digitas.Todo.Api.Mappers;

public static class TodoMapper
{
    public static TodoDTO ToDTO(this Domain.Entities.Todo todo)
    {
        return new TodoDTO
        {
            Title = todo.Title,
            Description = todo.Description,
            TagName = todo.Tag.Name,
            EndsAt = todo.EndsAt,
            Status = nameof(todo.Status),
            IsLate = todo.IsLate,
        };
    }

    public static Domain.Entities.Todo ToEntity(this TodoDTO todoDto)
    {
        if(!Enum.TryParse(todoDto.Status, out TodoStatus status))
        {
            status = TodoStatus.Pending;
        }

        return new Domain.Entities.Todo
        {
            Title = todoDto.Title,
            Description = todoDto.Description,
            EndsAt = todoDto.EndsAt,
            Status = status,
            Tag = new Domain.Entities.Tag
            {
                Name = todoDto.TagName,
            }
        };
    }
}
