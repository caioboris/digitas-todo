using B3Digitas.Todo.Business.Interfaces;

namespace B3Digitas.Todo.Business.Services;

public class TodoService : ITodoService
{
    public Task<Result> CreateAsync(Domain.Entities.Todo entity)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> GetByTitleAsync(string title)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateAsync(Domain.Entities.Todo entity)
    {
        throw new NotImplementedException();
    }
}
