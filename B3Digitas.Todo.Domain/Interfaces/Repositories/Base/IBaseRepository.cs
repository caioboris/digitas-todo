namespace B3Digitas.Todo.Domain.Interfaces.Repositories.Base;

public interface IBaseRepository<T>
{
    Task<Result<IEnumerable<T>>> GetAllAsync();
    Task<Result<T>> GetAsync(Guid id);
    Task<Result<T>> GetByTitleAsync(string title);
    Task<Result<T>> CreateAsync(T model);
    Task<Result<T>> UpdateAsync(T model);
    Task<Result<T>> DeleteAsync(Guid id);
}
