using LibraryManagement.ModelLibrary.Models;

namespace NotificationAppDataAccessLibrary.Repositories;

public class FineRepository : AbstractRepository<int, Fine>
{
    public override Fine? Get(int key)
    {
        //var book = libraryManagementContext.Book.Include(b => b.BookCategory).Include(bi=>bi.BookISBNs).ThenInclude(bc=>bc.BookCopies).ThenInclude(bs=>bs.BookStatus).Where(b => b.BookId == key).FirstOrDefault();
        return null;
    }
}