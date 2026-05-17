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
        var categoryList = bookCategoryRepository.GetAll();
        Console.WriteLine("\nThis Is The List Of The Catgory That Can Be Added");
        foreach (var category in categoryList)
        {
            Console.WriteLine("---------------------------\n");
            Console.WriteLine(category);
            Console.WriteLine("\n---------------------------");
        }
        Console.WriteLine("\nEnter The Category Id");
        int categoryId = inputsCheck.IdInputs();
        var catgory = bookCategoryRepository.Get(categoryId);
        if (catgory == null)
        {
            throw new InvalidBookException("Book Category Is Not Found. So Book Not Added");
        }
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
        var bookList = bookRepository.GetAllBooks();
        if (bookList.Count == 0)
        {
            throw new InvalidBookException("No Book Is Found In The Basic Book. Added That Initally");
        }
        Console.WriteLine("\nThis Is The List Of The Books That Can Be Added");
        foreach (var book in bookList)
        {
            Console.WriteLine(book.GetBooksByCategory());
        }
        Console.WriteLine("\nEnter The Book Id");
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
        var bookList = bookISBNRepository.GetAll();
        if (bookList.Count == 0)
        {
            throw new InvalidBookException("No Book Is Found In The Basic Book. Added That Initally");
        }
        Console.WriteLine("\nThis Is The List Of The Book ISBN That Can Be Added");
        foreach (var book in bookList)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine(book);
            Console.WriteLine("-------------------------");
        }
        Console.WriteLine("Enter The ISBN Book ID");
        int ISBN = inputsCheck.IdInputs();
        if (bookISBNRepository.Get(ISBN) == null)
        {
            throw new InvalidBookException("Book is Not Found In The List");
        }
        Console.WriteLine("Enter The Book Status ID");
        int bookStatusId;
        while (!int.TryParse(Console.ReadLine(), out bookStatusId) || bookStatusId < 0 || bookStatusId > 5)
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