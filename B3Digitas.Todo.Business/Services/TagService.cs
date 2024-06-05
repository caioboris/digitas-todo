using B3Digitas.Todo.Business.Interfaces;
using B3Digitas.Todo.Domain;
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

    public async Task<Result<Tag>> CreateAsync(Tag entity)
    {
        if (await ExistsTag(entity))
        {
            return new Result<Tag>
            {
                IsSuccess = false,
                Message = "Essa etiqueta já existe!"
            };
        }

        return await _tagRepository.CreateAsync(entity);
    }    

    public async Task<Result<Tag>> DeleteAsync(Guid id)
    {
       return await _tagRepository.DeleteAsync(id);   
    }

    public async Task<Result<IEnumerable<Tag>>> GetAllAsync()
    {
        return await _tagRepository.GetAllAsync();
    }

    public async Task<Result<Tag>> GetAsync(Guid id)
    {
       return await _tagRepository.GetAsync(id);
    }

    public async Task<Result<Tag>> GetByTitleAsync(string title)
    {
        return await _tagRepository.GetByTitleAsync(title);
    }

    public async Task<Result<Tag>> UpdateAsync(Guid id, Tag model)
    {
        model.Id = id;
        return await _tagRepository.UpdateAsync(model);
    }
    private async Task<bool> ExistsTag(Tag model)
    {
        var result = await _tagRepository.GetByTitleAsync(model.Name);
        return result.IsSuccess;
    }
}
