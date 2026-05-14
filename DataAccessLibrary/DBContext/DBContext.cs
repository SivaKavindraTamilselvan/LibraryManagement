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
        modelBuilder.Entity<Role>(r =>
        {
           r.HasKey(r=>r.RoleId).HasName("PK_Role_Id");
           r.HasIndex(r=>r.RoleName).IsUnique();
           r.HasData(new Role() {RoleId = 1,RoleName = "Admin"});
           r.HasData(new Role() {RoleId = 2,RoleName = "User"}) ;
        });

        modelBuilder.Entity<MemberType>(mt =>
        {
            mt.HasKey(mt => mt.MemberTypeId).HasName("PK_Member_Type_Id");
            mt.HasData(new MemberType() { MemberTypeId = 1, MemberTypeName = "Basic", NumberOfBooks = 2, LimitDays = 7 },
            new MemberType() { MemberTypeId = 2, MemberTypeName = "Student", NumberOfBooks = 3, LimitDays = 10 },
            new MemberType() { MemberTypeId = 3, MemberTypeName = "Premium", NumberOfBooks = 5, LimitDays = 15 });
        });
    }
}