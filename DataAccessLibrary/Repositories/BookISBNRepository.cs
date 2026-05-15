using LibraryManagement.ModelLibrary.Models;
using NotificationAppDataAccessLibrary.Repositories;

public class BookISBNRepository : AbstractRepository<int, BookISBN>
{
    public override BookISBN? Get(int key)
    {
        var book = libraryManagementContext.BookISBN.Where(b=>b.BookISBNId == key).FirstOrDefault();
        return book;
    }
}