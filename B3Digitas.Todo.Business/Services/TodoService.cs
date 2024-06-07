using B3Digitas.Todo.Api.Mappers;
using B3Digitas.Todo.Business.Models;
using B3Digitas.Todo.Domain;
using B3Digitas.Todo.Domain.Entities;
using B3Digitas.Todo.Domain.Interfaces.Repositories;
using B3Digitas.Todo.Domain.Interfaces.Services;

namespace B3Digitas.Todo.Business.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    private readonly ITagRepository _tagRepository;

    public TodoService(ITodoRepository todoRepository, ITagRepository tagRepository)
    {
        _todoRepository = todoRepository;
        _tagRepository = tagRepository;
    }

    public async Task<Result<TodoModel>> CreateAsync(TodoModel model)
    {
        try
        {
            if (await ExistsTodo(model))
            {
                return Result<TodoModel>.Failure("Essa tarefa ja existe!");
            }

            var entity = model.ToEntity();

            if (!string.IsNullOrEmpty(model.Tag.Name))
            {
                var tag = await _tagRepository.GetByTitleAsync(model.Tag.Name);

                if (tag is null)
                {
                    return Result<TodoModel>.Failure("Essa etiqueta nao existe.");
                }
                
                entity = model.ToEntity(tag);
            }

            var todo = await _todoRepository.CreateAsync(entity);

            return Result<TodoModel>.Success(todo.ToModel());
        }
        catch (Exception ex)
        {
            return Result<TodoModel>.Failure("Erro ao criar etiqueta", ex.Message);
        }
    }

    public async Task<Result<TodoModel>> DeleteAsync(Guid id)
    {
        try
        {
            var success = await _todoRepository.DeleteAsync(id);

            if (!success)
                return Result<TodoModel>.Failure("Tarefa nao encontrada.");

            return Result<TodoModel>.Success(null, "Tarefa excluida com sucesso.");
        }
        catch (Exception ex)
        {
            return Result<TodoModel>.Failure("Erro ao deletar tarefa.", ex.Message);
        }
    }

    public async Task<Result<IEnumerable<TodoModel>>> GetAllAsync()
    {
        try
        {
            var todos = await _todoRepository.GetAllAsync();
            return Result<IEnumerable<TodoModel>>.Success(todos.Select(x => x.ToModel()).ToList());
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<TodoModel>>.Failure("Erro ao criar tarefa.", ex.Message);
        }
    }

    public async Task<Result<TodoModel>> GetAsync(Guid id)
    {
        try
        {
            var todo = await _todoRepository.GetAsync(id);

            if (todo is null)
            {
                return Result<TodoModel>.Failure("Tarefa nao encontrada.");
            }

            return Result<TodoModel>.Success(todo.ToModel());

        }
        catch (Exception ex)
        {
            return Result<TodoModel>.Failure("Erro ao criar tarefa.", ex.Message);
        }
    }

    public async Task<Result<TodoModel>> GetByTitleAsync(string title)
    {
        try
        {
            var todo = await _todoRepository.GetByTitleAsync(title);

            if (todo is null)
            {
                return Result<TodoModel>.Failure("Tarefa nao encontrada.");
            }

            return Result<TodoModel>.Success(todo.ToModel());

        }
        catch (Exception ex)
        {
            return Result<TodoModel>.Failure("Erro ao criar tarefa.", ex.Message);
        }
    }

    public async Task<Result<TodoModel>> UpdateAsync(Guid id, TodoModel model)
    {
        try
        {
            model.Id = id;

            var entity = model.ToEntity();
            if (!string.IsNullOrEmpty(model.Tag.Name))
            {
                var tag = await _tagRepository.GetByTitleAsync(model.Tag.Name);

                if (tag is null)
                {
                    return Result<TodoModel>.Failure("Essa etiqueta não existe");
                }

                entity = model.ToEntity(tag);
            }

            var newTodo = await _todoRepository.UpdateAsync(entity);
            return Result<TodoModel>.Success(newTodo.ToModel());
        }
        catch (Exception ex)
        {
            return Result<TodoModel>.Failure("Erro ao criar tarefa.", ex.Message);
        }
    }

    private async Task<bool> ExistsTodo(TodoModel model)
    {
        var result = await _todoRepository.GetByTitleAsync(model.Title);
        return result != null;
    }
}
