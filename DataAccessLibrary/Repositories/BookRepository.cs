using LibraryManagement.ModelLibrary.Models;
using NotificationAppDataAccessLibrary.Repositories;

public class BookRepository : AbstractRepository<int, Book>
{
    public override Book? Get(int key)
    {
        var book = libraryManagementContext.Book.Where(b=>b.BookId == key).FirstOrDefault();
        return book;
    }
}