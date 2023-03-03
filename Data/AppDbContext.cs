using Microsoft.EntityFrameworkCore;
using MiniTodo.Models;
using MiniTodo.Services;

namespace MiniTodo.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>().HasData(
            new Todo(Guid.NewGuid(), "Teste 1", false, DateTime.Now),
            new Todo(Guid.NewGuid(), "Teste 2", false, DateTime.Now),
            new Todo(Guid.NewGuid(), "Teste 3", false, DateTime.Now),
            new Todo(Guid.NewGuid(), "Teste 4", false, DateTime.Now),
            new Todo(Guid.NewGuid(), "Teste 5", false, DateTime.Now)

        );
    }



    protected override void OnConfiguring(DbContextOptionsBuilder options)
                                        => options.UseSqlite("Data Source=./Data/app.db;Cache=Shared");

}
