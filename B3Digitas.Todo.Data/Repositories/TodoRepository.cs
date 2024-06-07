using B3Digitas.Todo.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace B3Digitas.Todo.Data.Repository;

public class TodoRepository : ITodoRepository
{
    private readonly DataContext _context;

    public TodoRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.Todo> CreateAsync(Domain.Entities.Todo todo)
    {
         _context.Todos.Add(todo);
         await _context.SaveChangesAsync();
         return todo;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var todo = await _context.Todos.FindAsync(id);
            
        if(todo == null)
        {
            return false;
        }
        
        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<Domain.Entities.Todo>> GetAllAsync()
    {
        return await _context.Todos.Include(x => x.Tag)
            .ToListAsync();
    }

    public async Task<Domain.Entities.Todo> GetAsync(Guid id)
    {
        
        return await _context.Todos.Include(x => x.Tag)
            .FirstOrDefaultAsync(y => y.Id == id);
    }

    public async Task<Domain.Entities.Todo> GetByTitleAsync(string title)
    {
       
        return await _context.Todos.Include(x => x.Tag)
            .FirstOrDefaultAsync(y => y.Title == title);
    }

    public async Task<Domain.Entities.Todo> UpdateAsync(Domain.Entities.Todo todo)
    {
        _context.Todos.Update(todo);
        await _context.SaveChangesAsync();
        return todo;
    }
}
