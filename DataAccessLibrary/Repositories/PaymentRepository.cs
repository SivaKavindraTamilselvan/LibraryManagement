using LibraryManagement.DataAccessLibrary.DBContext;
using LibraryManagement.ModelLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace NotificationAppDataAccessLibrary.Repositories;

public class PaymentRepository : AbstractRepository<int, Payment>
{
    public override Payment? Get(int key)
    {
        //var book = libraryManagementContext.Book.Include(b => b.BookCategory).Include(bi=>bi.BookISBNs).ThenInclude(bc=>bc.BookCopies).ThenInclude(bs=>bs.BookStatus).Where(b => b.BookId == key).FirstOrDefault();
        return null;
    }

    public Payment? CreatePayment(Payment payment)
    {
        using var context = new LibraryManagementContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            context.Database.ExecuteSqlInterpolated($"CALL pay_fine({payment.FineId},{payment.AmountPaid},{payment.ModeOfPaymentId})");
            transaction.Commit();
            var paidPayment = context.Payment.AsNoTracking().OrderByDescending(p => p.PaymentDate).FirstOrDefault(p => p.FineId == payment.FineId);
            return paidPayment;
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

    public List<Payment> GetPaymentsById(int id)
    {
        var payments = libraryManagementContext.Payment.Include(mp=>mp.ModeOfPayment).Include(f=>f.Fine).ThenInclude(br=>br.Borrowing).Where(m=>m.Fine!.Borrowing!.MemberId == id).ToList();
        return payments;
    }
}