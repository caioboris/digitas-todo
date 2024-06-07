using B3Digitas.Todo.Api.DTOs;
using B3Digitas.Todo.Business.Models;

namespace B3Digitas.Todo.Api.Mappers;

public static class TagMapper 
{
    public static TagDTO ToDto(this TagModel tagModel)
    {
        return new TagDTO
        {
            Color = tagModel.Color,
            Description = tagModel.Description,
            Name = tagModel.Name
        };
    }

    public static TagModel ToModel(this TagDTO tagDto)
    {
        return new TagModel
        {
            Name = tagDto.Name,
            Description = tagDto.Description,
            Color = tagDto.Color,
        };
    }

    public static TagModel ToModel(this TagDTO tagDto, Guid id)
    {
        return new TagModel
        {
            Id = id,
            Name = tagDto.Name,
            Description = tagDto.Description,
            Color = tagDto.Color,
        };
    }
}
