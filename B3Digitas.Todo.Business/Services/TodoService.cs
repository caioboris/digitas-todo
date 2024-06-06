using B3Digitas.Todo.Domain;
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

    public async Task<Result<Domain.Entities.Todo>> CreateAsync(Domain.Entities.Todo entity)
    {
        if(await ExistsTodo(entity))
        {
            return new Result<Domain.Entities.Todo>
            {
                IsSuccess = false,
                Message = "Essa tarefa já existe!"
            };
        }

        if (!string.IsNullOrEmpty(entity.Tag.Name))
        {
            var tagResult = await _tagRepository.GetByTitleAsync(entity.Tag.Name);

            if(!tagResult.IsSuccess || tagResult.ResponseBody is null)
            {
                return new Result<Domain.Entities.Todo>
                {
                    IsSuccess = false,
                    Message = "Etiqueta não encontrada"
                };
            }
            entity.Tag = tagResult.ResponseBody;
        }

        return await _todoRepository.CreateAsync(entity);
    }

    public async Task<Result<Domain.Entities.Todo>> DeleteAsync(Guid id)
    {
        return await _todoRepository.DeleteAsync(id);
    }

    public async Task<Result<IEnumerable<Domain.Entities.Todo>>> GetAllAsync()
    {
        return await _todoRepository.GetAllAsync(); 
    }

    public async Task<Result<Domain.Entities.Todo>> GetAsync(Guid id)
    {
        return await _todoRepository.GetAsync(id);
    }

    public async Task<Result<Domain.Entities.Todo>> GetByTitleAsync(string title)
    {
        return await _todoRepository.GetByTitleAsync(title);
    }

    public async Task<Result<Domain.Entities.Todo>> UpdateAsync(Guid id, Domain.Entities.Todo entity)
    {
        entity.Id = id;
        return await _todoRepository.UpdateAsync(entity);
    }

    private async Task<bool> ExistsTodo(Domain.Entities.Todo entity)
    {
        var result = await _todoRepository.GetByTitleAsync(entity.Title);
        return result.IsSuccess;
    }
}
