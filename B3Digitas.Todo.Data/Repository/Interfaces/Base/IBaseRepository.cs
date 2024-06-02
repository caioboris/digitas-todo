namespace B3Digitas.Todo.Data.Repository.Interfaces.Base;

public interface IBaseRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetAsync();
    Task<T> CreateAsync();
    Task UpdateAsync();
    Task DeleteAsync();
}
