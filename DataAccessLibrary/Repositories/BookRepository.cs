using LibraryManagement.ModelLibrary.Models;
using Microsoft.EntityFrameworkCore;
using NotificationAppDataAccessLibrary.Repositories;

public class BookRepository : AbstractRepository<int, Book>
{
    public override Book? Get(int key)
    {
        var book = libraryManagementContext.Book.Where(b=>b.BookId == key).FirstOrDefault();
        return book;
    }
    public List<Book>? GetBookByTitle(string title)
    {
        var books = libraryManagementContext.Book.Where(b=>b.BookTitle == title).Include(bi=>bi.BookISBNs).ThenInclude(bc=>bc.BookCopies).ToList();
        return books;
    }
}