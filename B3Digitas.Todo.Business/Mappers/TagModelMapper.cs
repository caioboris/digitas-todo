using B3Digitas.Todo.Business.Models;
using B3Digitas.Todo.Domain.Entities;

namespace B3Digitas.Todo.Api.Mappers;

public static class TagModelMapper 
{
    public static Tag ToEntity(this TagModel tag)
    {
        if(tag != null)
        {
            return new Tag
            {
                Id = tag.Id,
                Color = tag.Color,
                Description = tag.Description,
                Name = tag.Name
            };
        }

        return new Tag();
    }

    public static TagModel ToModel(this Tag tag)
    {
        if(tag != null)
        {
            return new TagModel
            {
                Id = tag.Id,
                Name = tag.Name,
                Description = tag.Description,
                Color = tag.Color,
            };
        }

        return new TagModel();
    }
}
