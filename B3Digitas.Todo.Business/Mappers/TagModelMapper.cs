using B3Digitas.Todo.Business.Models;
using B3Digitas.Todo.Domain.Entities;

namespace B3Digitas.Todo.Api.Mappers;

public static class TagModelMapper 
{
    public static Tag ToEntity(this TagModel tag)
    {
        return new Tag
        {
            Id = tag.Id,
            Color = tag.Color,
            Description = tag.Description,
            Name = tag.Name
        };
    }

    public static TagModel ToModel(this Tag tag)
    {
        return new TagModel
        {
            Id = tag.Id,
            Name = tag.Name,
            Description = tag.Description,
            Color = tag.Color,
        };
    }
}
