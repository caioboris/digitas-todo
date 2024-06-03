namespace B3Digitas.Todo.Business.Interfaces.Base;

public interface IBaseService<T>
{
    Task<Result> GetAllAsync();
    Task<Result> GetAsync(Guid id);
    Task<Result> GetByTitleAsync(string title);
    Task<Result> UpdateAsync(T entity);
    Task<Result> DeleteAsync(Guid id);
    Task<Result> CreateAsync(T entity);

}
