using LibraryManagement.ModelLibrary.Models;
using NotificationAppDataAccessLibrary.Repositories;

public class BookCopyRepository : AbstractRepository<int, BookCopy>
{
    public override BookCopy? Get(int key)
    {
        var book = libraryManagementContext.BookCopy.Where(b=>b.BookCopyId == key).FirstOrDefault();
        return book;
    }

    public BookCopy? GetBookByCopyNumber(string CopyNumber)
    {
        var book = libraryManagementContext.BookCopy.Where(b=>b.CopyNumber == CopyNumber).FirstOrDefault();
        return book;
    }
}