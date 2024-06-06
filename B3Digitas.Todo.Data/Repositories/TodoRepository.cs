using B3Digitas.Todo.Domain;
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

    public async Task<Result<Domain.Entities.Todo>> CreateAsync(Domain.Entities.Todo todo)
    {
        try
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return new Result<Domain.Entities.Todo>
            {
                IsSuccess = true,
                ResponseBody = todo
            };
        }
        catch (Exception e)
        {
            return new Result<Domain.Entities.Todo>
            {
                IsSuccess = false,
                Message = e.Message,
                Exception = e
            };
        }
    }

    public async Task<Result<Domain.Entities.Todo>> DeleteAsync(Guid id)
    {
        try
        {
            var todo = await _context.Todos.FindAsync(id);
            
            if(todo == null)
            {
                return new Result<Domain.Entities.Todo>
                {
                    IsSuccess = false,
                    Message = "Tarefa nao encontrada."
                };
            }
            
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return new Result<Domain.Entities.Todo>
            {
                IsSuccess = true,
                Message = "Tarefa excluida com sucesso"
            };

        }
        catch (Exception e)
        {
            return new Result<Domain.Entities.Todo>
            {
                IsSuccess = false,
                Message = "Erro ao excluir tarefa",
                Exception = e
            };
        }
    }

    public async Task<Result<IEnumerable<Domain.Entities.Todo>>> GetAllAsync()
    {
        try
        {
            var todos = await _context.Todos.Include(x => x.Tag)
                .ToListAsync();
            return new Result<IEnumerable<Domain.Entities.Todo>>
            {
                IsSuccess = true,
                ResponseBody = todos,
            };
        }
        catch (Exception ex)
        {
            return new Result<IEnumerable<Domain.Entities.Todo>>
            {
                IsSuccess = false,
                Message = "Erro ao obter lista de tarefas.",
                Exception= ex
            };
        }
    }

    public async Task<Result<Domain.Entities.Todo>> GetAsync(Guid id)
    {
        try
        {
            var todo = await _context.Todos.Include(x => x.Tag)
                .FirstOrDefaultAsync(y => y.Id == id);
            
            if (todo is null)
            {
                return new Result<Domain.Entities.Todo>
                {
                    IsSuccess = false,
                    Message = "Tarefa nao encontrada"
                };
            }

            return new Result<Domain.Entities.Todo>
            {
                IsSuccess = true,
                ResponseBody = todo
            };
        }
        catch (Exception ex)
        {
            return new Result<Domain.Entities.Todo>
            {
                IsSuccess = false,
                Message = "Erro ao obter tarefa",
                Exception = ex
            };
        }
    }

    public async Task<Result<Domain.Entities.Todo>> GetByTitleAsync(string title)
    {
        try
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Title == title);

            if(todo is null)
            {
                return new Result<Domain.Entities.Todo>
                {
                    IsSuccess = false,
                    Message = "Tarefa nao encontrada"
                };
            }

            return new Result<Domain.Entities.Todo>
            {
                IsSuccess = true,
                ResponseBody = todo
            };
        }
        catch (Exception e)
        {
            return new Result<Domain.Entities.Todo>
            {
                IsSuccess = false,
                Message = "Erro ao obter tarefa.",
                Exception = e
            };
        }
    }

    public async Task<Result<Domain.Entities.Todo>> UpdateAsync(Domain.Entities.Todo todo)
    {
        try
        {
            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();

            return new Result<Domain.Entities.Todo>
            {
                IsSuccess = true,
                Message = "Tarefa alterada com sucesso"
            };
        }
        catch (Exception e)
        {
            return new Result<Domain.Entities.Todo>
            {
                IsSuccess = false,
                Message = "Erro ao atualizar tarefa.",
                Exception = e
            };
        }
    }
}
