using B3Digitas.Todo.Domain;
using B3Digitas.Todo.Domain.Entities;
using B3Digitas.Todo.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace B3Digitas.Todo.Data.Repository;

public class TagRepository : ITagRepository
{
    private readonly DataContext _context;

    public TagRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Result<Tag>> CreateAsync(Tag Tag)
    {
        try
        {
            _context.Tags.Add(Tag);
            await _context.SaveChangesAsync();
            return new Result<Tag>
            {
                IsSuccess = true,
                ResponseBody = Tag
            };
        }
        catch (Exception e)
        {
            return new Result<Tag>
            {
                IsSuccess = false,
                Message = "Erro ao criar etiqueta.",
                Exception = e
            };
        }
    }

    public async Task<Result<Tag>> DeleteAsync(Guid id)
    {
        try
        {
            var Tag = await _context.Tags.FindAsync(id);

            if (Tag == null)
            {
                return new Result<Tag>
                {
                    IsSuccess = false,
                    Message = "Etiqueta nao encontrada."
                };
            }

            _context.Tags.Remove(Tag);
            await _context.SaveChangesAsync();

            return new Result<Tag>
            {
                IsSuccess = true,
                Message = "Etiqueta excluida com sucesso."
            };

        }
        catch (Exception e)
        {
            return new Result<Tag>
            {
                IsSuccess = false,
                Message = "Erro ao excluir etiqueta.",
                Exception = e
            };
        }
    }

    public async Task<Result<IEnumerable<Tag>>> GetAllAsync()
    {
        try
        {
            var Tags = await _context.Tags.ToListAsync();
            return new Result<IEnumerable<Tag>>
            {
                IsSuccess = true,
                ResponseBody = Tags,
            };
        }
        catch (Exception ex)
        {
            return new Result<IEnumerable<Tag>>
            {
                IsSuccess = false,
                Message = "Erro ao obter lista de tarefas.",
                Exception = ex
            };
        }
    }

    public async Task<Result<Tag>> GetAsync(Guid id)
    {
        try
        {
            var Tag = await _context.Tags.FindAsync(id);

            if (Tag is null)
            {
                return new Result<Tag>
                {
                    IsSuccess = false,
                    Message = "Etiqueta nao encontrada"
                };
            }

            return new Result<Tag>
            {
                IsSuccess = true,
                ResponseBody = Tag
            };
        }
        catch (Exception ex)
        {
            return new Result<Tag>
            {
                IsSuccess = false,
                Message = "Erro ao obter etiqueta",
                Exception = ex
            };
        }
    }

    public async Task<Result<Tag>> GetByTitleAsync(string title)
    {
        try
        {
            var Tag = await _context.Tags.FirstOrDefaultAsync(x => x.Name == title);

            if (Tag is null)
            {
                return new Result<Tag>
                {
                    IsSuccess = false,
                    Message = "Etiqueta nao encontrada"
                };
            }

            return new Result<Tag>
            {
                IsSuccess = true,
                ResponseBody = Tag
            };
        }
        catch (Exception e)
        {
            return new Result<Tag>
            {
                IsSuccess = false,
                Message = "Erro ao obter etiqueta.",
                Exception = e
            };
        }
    }

    public async Task<Result<Tag>> UpdateAsync(Tag Tag)
    {
        try
        {
            _context.Tags.Update(Tag);
            await _context.SaveChangesAsync();

            return new Result<Tag>
            {
                IsSuccess = true,
                Message = "Etiqueta alterada com sucesso"
            };
        }
        catch (Exception e)
        {
            return new Result<Tag>
            {
                IsSuccess = false,
                Message = "Erro ao atualizar etiqueta.",
                Exception = e
            };
        }
    }
}
