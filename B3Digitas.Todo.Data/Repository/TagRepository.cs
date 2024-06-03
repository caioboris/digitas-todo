﻿using B3Digitas.Todo.Domain.Entities;
using B3Digitas.Todo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace B3Digitas.Todo.Data.Repository;

public class TagRepository : ITagRepository
{
    private readonly DataContext _context;

    public TagRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Tag> CreateAsync(Tag tag)
    {
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();
        return tag;
    }

    public async Task DeleteAsync(Guid id)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag != null)
        {
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }

    }

    public async Task<List<Tag>> GetAllAsync()
    {
        return await _context.Tags.ToListAsync();
    }

    public async Task<Tag> GetAsync(Guid id)
    {
        return await _context.Tags.FindAsync(id);
    }

    public async Task<Tag> GetByTitleAsync(string title)
    {
        return await _context.Tags.FirstOrDefaultAsync(x => x.Name == title);
    }

    public async Task UpdateAsync(Tag tag)
    {
        _context.Tags.Update(tag);
        await _context.SaveChangesAsync();  
    }
}
