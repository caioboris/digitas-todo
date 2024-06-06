using B3Digitas.Todo.Domain;

namespace B3Digitas.Todo.Domain.Interfaces.Services.Base;

public interface IBaseService<T>
{
    Task<Result<IEnumerable<T>>> GetAllAsync();
    Task<Result<T>> GetAsync(Guid id);
    Task<Result<T>> GetByTitleAsync(string title);
    Task<Result<T>> UpdateAsync(Guid id, T entity);
    Task<Result<T>> DeleteAsync(Guid id);
    Task<Result<T>> CreateAsync(T entity);

}
