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
        if(createdBook == null)
        {
            throw new InvalidBookException("No Book Is Created");
        }
        return createdBook;
    }
}