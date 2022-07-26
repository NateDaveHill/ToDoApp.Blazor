using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class MyDbContext : DbContext
{
    public DbSet<ToDos> ToDos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=ToDo.db",
            options => { options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName); });
            base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDos>().ToTable("ToDos", "Test");
        modelBuilder.Entity<ToDos>(entity =>
        {
            entity.HasKey(e => e.ToDoId);
            entity.HasIndex(e => e.Title).IsUnique();
            entity.Property(e => e.DateTimeAdd).HasDefaultValue("CURRENT_TIMESTAMP");
        });
        base.OnModelCreating(modelBuilder);

    }
}


