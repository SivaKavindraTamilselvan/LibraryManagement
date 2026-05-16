using LibraryManagement.ModelLibrary.Models;
using Microsoft.EntityFrameworkCore;
using NotificationAppDataAccessLibrary.Repositories;

public class BookISBNRepository : AbstractRepository<int, BookISBN>
{
    public override BookISBN? Get(int key)
    {
        var book = libraryManagementContext.BookISBN.Where(b=>b.BookISBNId == key).FirstOrDefault();
        return book;
    }
    public BookISBN? GetBookByISBNNumber(string number)
    {
        var book = libraryManagementContext.BookISBN.Include(bn=>bn.Book).Where(b=>b.ISBN == number).FirstOrDefault();
        return book;
    }
}