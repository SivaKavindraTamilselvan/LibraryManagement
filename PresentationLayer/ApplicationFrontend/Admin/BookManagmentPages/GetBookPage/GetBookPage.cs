using LibraryManagement.ModelLibrary.Exceptions;
using LibraryManagement.ModelLibrary.Models;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class BookManagement
{
    public void GetAllBook()
    {
        var bookList = adminService.GetAllBooks();
        if (bookList == null)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        foreach (var book in bookList)
        {
            Console.WriteLine(book);
        }
    }

    public void GetBookByBookId(int id)
    {
        var book = adminService.GetBookByBookId(id);
        if (book == null)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        Console.WriteLine(book);
    }
    public void GetBookByBookTitle(string title)
    {
        var booklist = adminService.GetBookByBookTitle(title);
        if (booklist == null)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        foreach (var book in booklist)
        {
            Console.WriteLine(book);
        }
    }

    public void GetBookByBookAuthor(string author)
    {
        var booklist = adminService.GetBookByBookAuthor(author);
        if (booklist == null)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        foreach (var book in booklist)
        {
            Console.WriteLine(book);
        }
    }

    public void GetBookByBookISBNNumber(string isbn)
    {
        var book = adminService.GetBookByISBNNumber(isbn);
        if (book == null)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        Console.WriteLine(book);
    }

    public void GetBookByBookCopyNumber(string copy)
    {
        var book = adminService.GetBookByCopyNumber(copy);
        if (book == null)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        Console.WriteLine(book);
    }

    public void GetBookByCategoryId(int id)
    {
        var bookList = adminService.GetBookByCategory(id);
        if (bookList == null)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        foreach (var book in bookList)
        {
            Console.WriteLine(book.GetCategoryByBook());
        }
    }
}