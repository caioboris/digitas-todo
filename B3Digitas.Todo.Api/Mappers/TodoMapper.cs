using B3Digitas.Todo.Api.DTOs;
using B3Digitas.Todo.Business.Models;
using B3Digitas.Todo.Domain.Entities.Enums;

namespace B3Digitas.Todo.Api.Mappers;

public static class TodoMapper
{
    public static TodoDTO ToDto(this TodoModel todo)
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

    public static TodoModel ToEntity(this TodoDTO todoDto)
    {
        if(!Enum.TryParse(todoDto.Status, out TodoStatus status))
        {
            status = TodoStatus.Pending;
        }

        return new TodoModel
        {
            Title = todoDto.Title,
            Description = todoDto.Description,
            EndsAt = todoDto.EndsAt,
            Status = status,
            Tag = new TagModel
            {
                Name = todoDto.TagName,
            }
        };
    }

    public static TodoModel ToEntity(this TodoDTO todoDto, Guid id)
    {
        if (!Enum.TryParse(todoDto.Status, out TodoStatus status))
        {
            status = TodoStatus.Pending;
        }

        return new TodoModel
        {
            Id = id,
            Title = todoDto.Title,
            Description = todoDto.Description,
            EndsAt = todoDto.EndsAt,
            Status = status,
            Tag = new TagModel
            {
                Name = todoDto.TagName,
            }
        };
    }
}
