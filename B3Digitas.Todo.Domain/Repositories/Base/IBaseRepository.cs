namespace B3Digitas.Todo.Domain.Repositories.Base;

public interface IBaseRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetAsync(Guid id);
    Task<T> GetByTitleAsync(string title);
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}
