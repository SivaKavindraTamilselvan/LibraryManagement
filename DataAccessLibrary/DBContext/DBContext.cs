using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using LibraryManagement.ModelLibrary.Models;

namespace LibraryManagement.DataAccessLibrary.DBContext;

public class LibraryManagementContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Env.Load();
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString"));
    }
    public DbSet<MemberType> MemberTypes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MemberType>(mt =>
        {
            mt.HasKey(mt => mt.MemberTypeId).HasName("PK_Member_Type_Id");
            mt.HasData(new MemberType() { MemberTypeId = 1, MemberTypeName = "Basic", Number_Of_Books = 2, Limit_Days = 7 },
            new MemberType() { MemberTypeId = 2, MemberTypeName = "Student", Number_Of_Books = 3, Limit_Days = 10 },
            new MemberType() { MemberTypeId = 3, MemberTypeName = "Premium", Number_Of_Books = 5, Limit_Days = 15 });
        });
    }
}