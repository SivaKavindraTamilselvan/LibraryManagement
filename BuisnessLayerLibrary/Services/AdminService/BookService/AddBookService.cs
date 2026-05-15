using LibraryManagement.ModelLibrary.Exceptions;
using LibraryManagement.ModelLibrary.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public partial class AdminService
{
    public Book? AddBook()
    {
        Book book = new Book();
        Console.WriteLine("Enter The Book Title");
        string BookTitle = Console.ReadLine() ?? "";
        while (BookTitle.Trim() == "")
        {
            Console.WriteLine("Invalid Book Title.Book Title Should Not be Empty.Enter Valid Name");
            BookTitle = Console.ReadLine() ?? "";
        }

        Console.WriteLine("Enter The Book Author");
        string Author = Console.ReadLine() ?? "";
        while (Author.Trim() == "")
        {
            Console.WriteLine("Invalid Book Title.Book Title Should Not be Empty.Enter Valid Name");
            Author = Console.ReadLine() ?? "";
        }
        int categoryId = inputsCheck.IdInputs();
        book.BookCategoryId = categoryId;
        book.Author = Author;
        book.BookTitle = BookTitle;

        var createdBook = bookRepository.Create(book);
        if (createdBook == null)
        {
            throw new InvalidBookException("No Book Is Created");
        }
        return createdBook;
    }

    public BookISBN? AddBookISBN()
    {
        BookISBN bookISBN = new BookISBN();
        int year = inputsCheck.YearInputs();

        Console.WriteLine("Enter The Edition");
        int Edition;
        while (!int.TryParse(Console.ReadLine(), out Edition) || Edition < 0)
        {
            Console.WriteLine("Enter The Valid Edition Number");
        }
        int bookId = inputsCheck.IdInputs();
        if (bookRepository.Get(bookId) == null)
        {
            throw new InvalidBookException("Book is Not Found In The List");
        }
        bookISBN.PublishedYear = year;
        bookISBN.Edition = Edition;
        bookISBN.BookId = bookId;
        bookISBN.ISBN = generateUnique.GenerateISBN();
        var createdBookISBN = bookISBNRepository.Create(bookISBN);
        return createdBookISBN;
    }
    public BookCopy? AddBookCopy()
    {
        BookCopy bookISBN = new BookCopy();
        // need to add validation
        Console.WriteLine("Enter The ISBN Book ID");
        int ISBN = inputsCheck.IdInputs();
        if (bookISBNRepository.Get(ISBN) == null)
        {
            throw new InvalidBookException("Book is Not Found In The List");
        }
        Console.WriteLine("Enter The Book Status ID");
        int bookStatusId;
        while(!int.TryParse(Console.ReadLine(),out bookStatusId) || bookStatusId<0 || bookStatusId>5)
        {
            Console.WriteLine("Enter Valid Book Status ID");
        }
        bookISBN.CopyNumber = generateUnique.GenerateCopy();
        bookISBN.BookStatusId = bookStatusId;
        bookISBN.BookISBNId = ISBN;
        var createdBookISBN = bookCopyRepository.Create(bookISBN);
        return createdBookISBN;
    }
}