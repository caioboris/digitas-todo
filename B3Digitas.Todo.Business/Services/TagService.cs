using B3Digitas.Todo.Api.Mappers;
using B3Digitas.Todo.Business.Models;
using B3Digitas.Todo.Domain;
using B3Digitas.Todo.Domain.Entities;
using B3Digitas.Todo.Domain.Interfaces.Repositories;
using B3Digitas.Todo.Domain.Interfaces.Services;

namespace B3Digitas.Todo.Business.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Result<TagModel>> CreateAsync(TagModel model)
    {
        try
        {
            if (await ExistsTag(model.ToEntity()))
            {
                return Result<TagModel>.Failure("Essa etique ja existe!");
            }

            var tag = await _tagRepository.CreateAsync(model.ToEntity());
            return Result<TagModel>.Success(tag.ToModel());
        }
        catch (Exception ex)
        {
            return Result<TagModel>.Failure("Erro ao criar etiqueta.", ex);
        }
    }    

    public async Task<Result<TagModel>> DeleteAsync(Guid id)
    {
        try
        {
            var success = await _tagRepository.DeleteAsync(id);

            if (!success)
                return Result<TagModel>.Failure("Etiqueta nao encontrada.");

            return Result<TagModel>.Success(null, "Etique excluida com sucesso.");
        }
        catch (Exception ex)
        {
            return Result<TagModel>.Failure("Erro ao criar etiqueta.", ex);
        } 
    }

    public async Task<Result<IEnumerable<TagModel>>> GetAllAsync()
    {
        try
        {
            var tags = await _tagRepository.GetAllAsync();
            return Result<IEnumerable<TagModel>>.Success(tags.Select(x => x.ToModel()).ToList());

        }
        catch (Exception ex)
        {
            return Result<IEnumerable<TagModel>>.Failure("Erro ao criar etiqueta.", ex);
        }
    }

    public async Task<Result<TagModel>> GetAsync(Guid id)
    {
        try
        {
            var tag = await _tagRepository.GetAsync(id);

            if(tag is null)
            {
                return Result<TagModel>.Failure("Etiqueta nao encontrada.");
            }

            return Result<TagModel>.Success(tag.ToModel());

        }
        catch (Exception ex)
        {
            return Result<TagModel>.Failure("Erro ao criar etiqueta.", ex);
        }
    }

    public async Task<Result<TagModel>> GetByTitleAsync(string title)
    {
        try
        {
            var tag = await _tagRepository.GetByTitleAsync(title);

            if (tag is null)
            {
                return Result<TagModel>.Failure("Etiqueta nao encontrada.");
            }

            return Result<TagModel>.Success(tag.ToModel());

        }
        catch (Exception ex)
        {
            return Result<TagModel>.Failure("Erro ao criar etiqueta.", ex);
        }
    }

    public async Task<Result<TagModel>> UpdateAsync(Guid id,TagModel model)
    {
        try
        {
            model.Id = id;
            var newTag = await _tagRepository.UpdateAsync(model.ToEntity());
            return Result<TagModel>.Success(newTag.ToModel());
        }
        catch (Exception ex)
        {
            return Result<TagModel>.Failure("Erro ao criar etiqueta.", ex);
        }
    }

    private async Task<bool> ExistsTag(Tag model)
    {
        var result = await _tagRepository.GetByTitleAsync(model.Name);
        return result != null;
    }
}
