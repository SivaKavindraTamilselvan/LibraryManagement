using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace LibraryManagement.DataAccessLibrary.DBContext;

public class LibraryManagementContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Env.Load();
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString"));
    }
}