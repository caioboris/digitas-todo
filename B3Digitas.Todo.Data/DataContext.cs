using Microsoft.EntityFrameworkCore;

namespace B3Digitas.Todo.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Entities.Todo> Todos { get; set; }
    public DbSet<Entities.Tag> Tags { get; set; }
}
