using System.Transactions;
using LibraryManagement.DataAccessLibrary.DBContext;
using LibraryManagement.ModelLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace NotificationAppDataAccessLibrary.Repositories;

public class BorrowingRepository : AbstractRepository<int, Borrowing>
{
    public override Borrowing? Get(int BorrowingId)
    {
        var borrowing = libraryManagementContext.Borrowing.Include(m => m.Member).Include(b => b.BookCopy).Where(b => b.BorrowingId == BorrowingId).FirstOrDefault();
        return borrowing;
    }

    public Borrowing? CreateBorrowing(int memberId, int bookId)
    {
        using var context = new LibraryManagementContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            context.Database.ExecuteSqlInterpolated($"CALL check_borrowing_rules({memberId},{bookId})");
            transaction.Commit();
            var borrowing = context.Borrowing.AsNoTracking().Where(b => b.MemberId == memberId).OrderByDescending(b => b.BorrowedDate).FirstOrDefault();
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

    public Borrowing? ReturnBorrowing(int borrowId, bool lost, int damagedLevel)
    {
        using var context = new LibraryManagementContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (damagedLevel == 0)
            {
                context.Database.ExecuteSqlInterpolated($"CALL return_book({borrowId},{lost})");
            }
            else
            {
                context.Database.ExecuteSqlInterpolated($"CALL return_book({borrowId},{lost},{damagedLevel})");
            }
            transaction.Commit();
            var borrowing = context.Borrowing.AsNoTracking().Where(b => b.BorrowingId == borrowId).FirstOrDefault();
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

    public List<Borrowing> GetBorrowingByMemberId(int memberId)
    {
        var borrowing = libraryManagementContext.Borrowing.Include(m => m.Member).Include(b => b.BookCopy).Where(b => b.MemberId == memberId).ToList();
        return borrowing;
    }

    public List<Borrowing> GetBorrowingByMemberEmail(string email)
    {
        var borrowing = libraryManagementContext.Borrowing.Include(m => m.Member).Include(b => b.BookCopy).Where(b => b.Member != null && b.Member.Email == email).ToList();
        return borrowing;
    }

    public List<Borrowing> GetBorrowingByBorrowingStatus(int id)
    {
        var borrowing = libraryManagementContext.Borrowing.Include(m => m.Member).ThenInclude(r=>r!.Role).Include(m=>m.Member).ThenInclude(mt=>mt!.MemberType).Include(b => b.BookCopy).ThenInclude(bi=>bi!.BookISBN).ThenInclude(b=>b!.Book).Where(b => b.BorrowingStatusId == id).ToList();
        return borrowing;
    }

    public List<Borrowing> GetBorrowingByBorrowingBorrowdate(DateTime dateTime)
    {
        var borrowing = libraryManagementContext.Borrowing.Include(m => m.Member).Include(b => b.BookCopy).Where(b => b.BorrowedDate.Date == dateTime.Date).ToList();
        return borrowing;
    }

    public List<Borrowing> GetBorrowingByBorrowingDuedate(DateTime dateTime)
    {
        var borrowing = libraryManagementContext.Borrowing.Include(m => m.Member).Include(b => b.BookCopy).Where(b => b.DueDate.Date == dateTime.Date).ToList();
        return borrowing;
    }
    public List<Borrowing> GetBorrowingByBorrowingReturndate(DateTime dateTime)
    {
        var borrowing = libraryManagementContext.Borrowing.Include(m => m.Member).Include(b => b.BookCopy).Where(b => b.ReturnDate.HasValue && b.ReturnDate.Value.Date == dateTime.Date).ToList();
        return borrowing;
    }

    public List<Borrowing> GetBorrowingByBorrowingDueByTommorrow()
    {
        var borrowing = libraryManagementContext.Borrowing.Include(m => m.Member).Include(b => b.BookCopy).Where(b => b.ReturnDate == DateTime.Now.AddDays(1)).ToList();
        return borrowing;
    }

    public List<Borrowing> GetBorrowingByBorrowingByTitle(string title)
    {
        var borrowing = libraryManagementContext.Borrowing.Include(m => m.Member).Include(b => b.BookCopy).ThenInclude(bi => bi!.BookISBN).ThenInclude(b => b!.Book).Where(b => b.BookCopy!.BookISBN!.Book!.BookTitle == title).ToList();
        return borrowing;
    }

    public List<Borrowing> GetBorrowingByBorrowingByBookCopyId(int id)
    {
        var borrowing = libraryManagementContext.Borrowing.Include(m => m.Member).Include(b => b.BookCopy).Where(b => b.BookCopyId == id).ToList();
        return borrowing;
    }

    public List<Borrowing> GetPendingReturn()
    {
        var borrowing = libraryManagementContext.Borrowing.Include(m=>m.Member).ThenInclude(mt=>mt.MemberType).Include(m => m.Member).Include(b => b.BookCopy).Where(b => b.ReturnDate == null).ToList();
        return borrowing;
    }

    public List<Borrowing> GetOverDueBooks()
    {
        var borrowing = libraryManagementContext.Borrowing.Include(m=>m.Member).ThenInclude(mt=>mt.MemberType).Include(m=>m.Member).ThenInclude(r=>r.Role).Include(bc=>bc.BookCopy).ThenInclude(bi=>bi.BookISBN).ThenInclude(b=>b.Book).Include(br=>br.BorrowingStatus).Where(br=>br.ReturnDate == null && br.DueDate.Date < DateTime.Now.Date).ToList();
        return borrowing;
    }

}