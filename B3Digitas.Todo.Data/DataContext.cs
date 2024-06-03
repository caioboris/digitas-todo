using B3Digitas.Todo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace B3Digitas.Todo.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Domain.Entities.Todo> Todos { get; set; }
    public DbSet<Tag> Tags { get; set; }
}
