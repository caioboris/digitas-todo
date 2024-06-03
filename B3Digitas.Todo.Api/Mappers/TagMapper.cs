﻿using B3Digitas.Todo.Api.DTOs;
using B3Digitas.Todo.Domain.Entities;

namespace B3Digitas.Todo.Api.Mappers;

public static class TagMapper 
{
    public static TagDTO ToDto(this Tag tag)
    {
        return new TagDTO
        {
            Id = tag.Id,
            Color = tag.Color,
            Description = tag.Description,
            Name = tag.Name
        };
    }

    public static Tag ToEntity(this TagDTO tagDto)
    {
        return new Tag
        {
            Id = tagDto.Id,
            Name = tagDto.Name,
            Description = tagDto.Description,
            Color = tagDto.Color,
        };
    }
}