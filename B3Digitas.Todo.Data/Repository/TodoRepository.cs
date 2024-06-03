using B3Digitas.Todo.Data.Repository.Interfaces;

namespace B3Digitas.Todo.Data.Repository;

public class TodoRepository : ITodoRepository
{
    public Task<Domain.Entities.Todo> CreateAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Domain.Entities.Todo>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Todo> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync()
    {
        throw new NotImplementedException();
    }
}
