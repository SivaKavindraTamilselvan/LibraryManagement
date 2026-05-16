using LibraryManagement.ModelLibrary.Models;
using Microsoft.EntityFrameworkCore;
using NotificationAppDataAccessLibrary.Repositories;

public class BookRepository : AbstractRepository<int, Book>
{
    public override Book? Get(int key)
    {
        var book = libraryManagementContext.Book.Include(b => b.BookCategory).Include(bi=>bi.BookISBNs).ThenInclude(bc=>bc.BookCopies).ThenInclude(bs=>bs.BookStatus).Where(b => b.BookId == key).FirstOrDefault();
        return book;
    }
    public List<Book>? GetBookByTitle(string title)
    {
        var books = libraryManagementContext.Book.Where(b => b.BookTitle == title).Include(bc=>bc.BookCategory).Include(bi => bi.BookISBNs).ThenInclude(bc => bc.BookCopies).ToList();
        return books;
    }

    public List<Book>? GetBookByAuthor(string author)
    {
        var books = libraryManagementContext.Book.Where(b => b.Author == author).Include(bc=>bc.BookCategory).Include(bi => bi.BookISBNs).ThenInclude(bc => bc.BookCopies).ToList();
        return books;
    }
}