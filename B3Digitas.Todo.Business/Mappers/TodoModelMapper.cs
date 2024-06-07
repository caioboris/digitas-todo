using B3Digitas.Todo.Business.Models;
using B3Digitas.Todo.Domain.Entities;

namespace B3Digitas.Todo.Api.Mappers;

public static class TodoModelMapper
{
    public static TodoModel ToModel(this Domain.Entities.Todo todo)
    {
        if (todo != null)
        {
            return new TodoModel
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Tag = todo.Tag.ToModel(),
                EndsAt = todo.EndsAt,
                Status = todo.Status,
                IsLate = todo.IsLate,
            };
        }
        return new TodoModel();
    }

    public static Domain.Entities.Todo ToEntity(this TodoModel todoModel)
    {
        if(todoModel != null)
        {
            return new Domain.Entities.Todo
            {
                Id = todoModel.Id,
                Title = todoModel.Title,
                Description = todoModel.Description,
                EndsAt = todoModel.EndsAt,
                Tag = null,
                Status = todoModel.Status
            };
        }

        return new Domain.Entities.Todo();
    }

    public static Domain.Entities.Todo ToEntity(this TodoModel todoModel, Tag tag)
    {
        if (todoModel != null)
        {
            return new Domain.Entities.Todo
            {
                Id = todoModel.Id,
                Title = todoModel.Title,
                Description = todoModel.Description,
                EndsAt = todoModel.EndsAt,
                Status = todoModel.Status,
                Tag = tag
            };
        }

        return new Domain.Entities.Todo();
    }
}
