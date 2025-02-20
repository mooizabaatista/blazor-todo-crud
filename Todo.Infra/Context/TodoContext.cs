using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Infra.Context;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> opt):base(opt)
    {
        
    }

    public TodoContext()
    {
        
    }

    public DbSet<TodoEntity> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoContext).Assembly);
    }
}
