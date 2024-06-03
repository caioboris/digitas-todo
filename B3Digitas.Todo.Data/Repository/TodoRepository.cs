using B3Digitas.Todo.Data.Repository.Interfaces;

namespace B3Digitas.Todo.Data.Repository;

public class TodoRepository : ITodoRepository
{
    public Task<Domain.Entities.Todo> CreateAsync(Domain.Entities.Todo todo)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Domain.Entities.Todo>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Todo> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Todo> GetByTitleAsync(string title)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Domain.Entities.Todo todo)
    {
        throw new NotImplementedException();
    }
}
