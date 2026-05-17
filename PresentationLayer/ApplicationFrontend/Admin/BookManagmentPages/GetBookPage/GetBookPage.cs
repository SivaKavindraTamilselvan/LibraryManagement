using LibraryManagement.ModelLibrary.Exceptions;
using LibraryManagement.ModelLibrary.Models;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class BookManagement
{
    public void GetAllBook()
    {
        var bookList = adminService.GetAllBooks();
        if (bookList.Count == 0)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        foreach (var book in bookList)
        {
            Console.WriteLine(book.GetAllBooks());
        }
    }

    public void GetBookByBookId(int id)
    {
        var book = adminService.GetBookByBookId(id);
        if (book == null)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        Console.WriteLine(book.GetAllBooks());
    }
    public void GetBookByBookTitle(string title)
    {
        var booklist = adminService.GetBookByBookTitle(title);
        if (booklist.Count == 0)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        foreach (var book in booklist)
        {
            Console.WriteLine(book.GetAllBooks());
        }
    }

    public void GetBookByBookAuthor(string author)
    {
        var booklist = adminService.GetBookByBookAuthor(author);
        if (booklist.Count == 0)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        foreach (var book in booklist)
        {
            Console.WriteLine(book.GetAllBooks());
        }
    }

    public void GetBookByBookISBNNumber(string isbn)
    {
        var booklist = adminService.GetBookByISBNNumber(isbn);
        if (booklist.Count == 0)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        foreach (var book in booklist)
        {
            Console.WriteLine(book.GetAllBookISBN());
        }
    }

    public void GetBookByBookCopyNumber(string copy)
    {
        var book = adminService.GetBookByCopyNumber(copy);
        if (book == null)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        Console.WriteLine(book.GetAllBookCopyByCopyNumber());
    }

    public void GetBookByCategoryId(int id)
    {
        Console.WriteLine("\n\n============== Book Details By Category ID ==============\n");
        var bookList = adminService.GetBookByCategory(id);
        if (bookList.Count == 0)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        foreach (var book in bookList)
        {
            Console.WriteLine(book.GetCategoryByBook());
        }
        Console.WriteLine("\n====================================================\n\n");
    }
    public void GetBookByStatus(int id)
    {
        Console.WriteLine("\n\n============== Book Details By Status ==============\n");
        var bookList = adminService.GetBookByStatus(id);
        if (bookList.Count == 0)
        {
            throw new InvalidBookException("No Book Found In The List");
        }
        foreach (var book in bookList)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine(book);
            Console.WriteLine("----------------------------------");
        }
        Console.WriteLine("\n====================================================\n\n");
    }
}