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
        // need to add validation
        int year = Convert.ToInt32(Console.ReadLine());
        int Edition = Convert.ToInt32(Console.ReadLine());
        //need to check if book id is there
        int bookId = inputsCheck.IdInputs();
        bookISBN.PublishedYear= year;
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
        int ISBN = inputsCheck.IdInputs();
        //need to check if book id is there
        int bookStatusId = inputsCheck.IdInputs();
        //string isbnNumber = bookISBNRepository.Get(ISBN);
        bookISBN.CopyNumber = generateUnique.GenerateCopy();
        bookISBN.BookStatusId = bookStatusId;
        bookISBN.BookISBNId = ISBN;
        var createdBookISBN = bookCopyRepository.Create(bookISBN);
        return createdBookISBN;
    }
}