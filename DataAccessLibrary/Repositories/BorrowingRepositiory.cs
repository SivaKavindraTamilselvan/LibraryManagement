using System.Transactions;
using LibraryManagement.ModelLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace NotificationAppDataAccessLibrary.Repositories;

public class BorrowingRepository : AbstractRepository<int, Borrowing>
{
    public override Borrowing? Get(int BorrowingId)
    {
        var borrowing = libraryManagementContext.Borrowing.Where(b => b.BorrowingId == BorrowingId).FirstOrDefault();
        return borrowing;
    }

    public Borrowing? CreateBorrowing(int memberId, int bookId)
    {
        using var transaction = libraryManagementContext.Database.BeginTransaction();
        try
        {
            libraryManagementContext.Database.ExecuteSqlInterpolated($"CALL check_borrowing_rules({memberId},{bookId})");
            transaction.Commit();
            var borrowing = libraryManagementContext.Borrowing.Where(b => b.MemberId == memberId).OrderByDescending(b => b.BorrowedDate).FirstOrDefault();
            return borrowing;
        }
        catch (PostgresException ex)
        {
            Console.WriteLine(ex.MessageText);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine(ex.Message);
        }
        return null;
    }
}