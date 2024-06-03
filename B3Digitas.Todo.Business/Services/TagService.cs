using B3Digitas.Todo.Business.Interfaces;
using B3Digitas.Todo.Domain.Entities;
using B3Digitas.Todo.Domain.Repositories;

namespace B3Digitas.Todo.Business.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Result> CreateAsync(Tag entity)
    {
        try
        {
            var tag = await _tagRepository.CreateAsync(entity);
            return new Result
            {
                IsSucces = true,
                ResultBody = tag
            };
        }
        catch (Exception e)
        {
            return new Result
            {
                IsSucces = false,
                Exception = e,
                ResultBody = e.Message
            };
        }
    }

    public async Task<Result> DeleteAsync(Guid id)
    {
        try
        {
            await _tagRepository.DeleteAsync(id);
            return new Result
            {
                IsSucces = true
            };
        }
        catch (Exception ex)
        {
            return new Result
            {
                IsSucces = false,
                Exception = ex,
                ResultBody = ex.Message
            };
        }
    }

    public async Task<Result> GetAllAsync()
    {
        try
        {
            List<Tag> tags = await _tagRepository.GetAllAsync();

            return new Result
            {
                IsSucces = true,
                ResultBody = tags
            };
        }
        catch(Exception e)
        {
            return new Result
            {
                IsSucces = false,
                ResultBody = e.Message,
                Exception = e 
            };
        }
    }

    public async Task<Result> GetAsync(Guid id)
    {
        try
        {
            var tag = await _tagRepository.GetAsync(id);
            return new Result
            {
                IsSucces = true,
                ResultBody = tag
            };
        }
        catch (Exception e)
        {
            return new Result
            {
                IsSucces = false,
                ResultBody = e.Message,
                Exception = e
            };
        }
    }

    public async Task<Result> GetByTitleAsync(string title)
    {
        try
        {
            var tag = await _tagRepository.GetByTitleAsync(title);
            return new Result
            {
                IsSucces = true,
                ResultBody = tag
            };
        }
        catch (Exception e)
        {
            return new Result
            {
                IsSucces = false,
                ResultBody = e.Message,
                Exception = e
            };
        }
    }

    public async Task<Result> UpdateAsync(Tag entity)
    {
        try
        {
            await _tagRepository.UpdateAsync(entity);
            return new Result
            {
                IsSucces = true
            };
        }
        catch (Exception e)
        {
            return new Result
            {
                IsSucces = false,
                Exception = e,
                ResultBody = e.Message
            };
        }
    }
}
