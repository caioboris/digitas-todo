namespace B3Digitas.Todo.Domain.Interfaces.Repositories.Base;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(Guid id);
    Task<T> GetByTitleAsync(string title);
    Task<T> CreateAsync(T model);
    Task<T> UpdateAsync(T model);
    Task<bool> DeleteAsync(Guid id);
}
