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
            r.HasKey(r => r.RoleId).HasName("PK_Role_Id");
            r.HasIndex(r => r.RoleName).IsUnique();
            r.HasData(new Role() { RoleId = 1, RoleName = "Admin" });
            r.HasData(new Role() { RoleId = 2, RoleName = "User" });
        });

        modelBuilder.Entity<MemberType>(mt =>
        {
            mt.HasKey(mt => mt.MemberTypeId).HasName("PK_Member_Type_Id");
            mt.HasData(new MemberType() { MemberTypeId = 1, MemberTypeName = "Basic", NumberOfBooks = 2, LimitDays = 7 },
            new MemberType() { MemberTypeId = 2, MemberTypeName = "Student", NumberOfBooks = 3, LimitDays = 10 },
            new MemberType() { MemberTypeId = 3, MemberTypeName = "Premium", NumberOfBooks = 5, LimitDays = 15 });
        });

        modelBuilder.Entity<BookStatus>(bs =>
        {
            bs.HasKey(bs => bs.BookStatusId).HasName("PK_Book_Status");
            bs.HasIndex(bs => bs.BookStatusName).IsUnique();
            bs.HasData(new BookStatus() { BookStatusId = 1, BookStatusName = "Available" });
            bs.HasData(new BookStatus() { BookStatusId = 2, BookStatusName = "Unavailable" });
            bs.HasData(new BookStatus() { BookStatusId = 3, BookStatusName = "Lost" });
            bs.HasData(new BookStatus() { BookStatusId = 4, BookStatusName = "Damaged" });
        });

        modelBuilder.Entity<BorrowingStatus>(bs =>
        {
            bs.HasKey(bs => bs.BorrowingStatusId).HasName("PK_Borrowing_Status");
            bs.HasIndex(bs => bs.BorrowingStatusName).IsUnique();
            bs.HasData(new BorrowingStatus() { BorrowingStatusId = 1, BorrowingStatusName = "Borrowed" });
            bs.HasData(new BorrowingStatus() { BorrowingStatusId = 2, BorrowingStatusName = "Returned" });
            bs.HasData(new BorrowingStatus() { BorrowingStatusId = 3, BorrowingStatusName = "OverDue" });
        });

        modelBuilder.Entity<FineCategory>(fc =>
        {
            fc.HasKey(fc => fc.FineCategoryId).HasName("PK_Fine_Category");
            fc.HasIndex(fc => fc.FineCategoryName).IsUnique();
            fc.HasData(new FineCategory() { FineCategoryId = 1, FineCategoryName = "Lost" });
            fc.HasData(new FineCategory() { FineCategoryId = 2, FineCategoryName = "Damaged" });
            fc.HasData(new FineCategory() { FineCategoryId = 3, FineCategoryName = "OverDue" });
        });

        modelBuilder.Entity<ModeOfPayment>(mp =>
        {
            mp.HasKey(mp => mp.ModeOfPaymentId).HasName("PK_Mode_Of_Payment");
            mp.HasIndex(mp => mp.ModeOfPaymentName).IsUnique();
            mp.HasData(new ModeOfPayment() { ModeOfPaymentId = 1, ModeOfPaymentName = "COD" });
            mp.HasData(new ModeOfPayment() { ModeOfPaymentId = 2, ModeOfPaymentName = "UPI" });
            mp.HasData(new ModeOfPayment() { ModeOfPaymentId = 3, ModeOfPaymentName = "Credit_Card" });
            mp.HasData(new ModeOfPayment() { ModeOfPaymentId = 4, ModeOfPaymentName = "Debit_Card" });
        });

        modelBuilder.Entity<DamagedLevel>(dl =>
        {
            dl.HasKey(dl => dl.DamagedLevelId).HasName("PK_Damaged_Level");
            dl.HasIndex(dl => dl.DamagedLevelName).IsUnique();
            dl.HasData(new DamagedLevel() { DamagedLevelId = 1, DamagedLevelName = "Little",FineAmount = 100 });
            dl.HasData(new DamagedLevel() { DamagedLevelId = 1, DamagedLevelName = "Medium" ,FineAmount = 300});
            dl.HasData(new DamagedLevel() { DamagedLevelId = 1, DamagedLevelName = "Hard" ,FineAmount = 500});
        });
    }
}