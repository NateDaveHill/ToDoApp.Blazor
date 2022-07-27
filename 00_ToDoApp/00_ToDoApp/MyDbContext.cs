using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class MyDbContext : DbContext
{
    public DbSet<ToDos> ToDos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionsStringBuilder = new SqliteConnectionStringBuilder { DataSource = "ToDos.db"};
        var connectionString = connectionsStringBuilder.ToString();
        var connection = new SqliteConnection(connectionString);

        optionsBuilder.UseSqlite(connection);

    }
}


