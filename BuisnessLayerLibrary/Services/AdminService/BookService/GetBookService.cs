using LibraryManagement.ModelLibrary.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public partial class AdminService
{
    public List<Book> GetAllBooks()
    {
        var bookList = bookRepository.GetAll();
        return bookList;
    }
    public Book? GetBookByBookId(int id)
    {
        var book = bookRepository.Get(id);
        return book;
    }
    public List<Book>? GetBookByBookTitle(string Title)
    {
        var book = bookRepository.GetBookByTitle(Title);
        return book;
    }
    public List<Book>? GetBookByBookAuthor(string author)
    {
        var booklist = bookRepository.GetBookByAuthor(author);
        return booklist;
    }
    public BookISBN? GetBookByISBNNumber(string number)
    {
        var book = bookISBNRepository.GetBookByISBNNumber(number);
        return book;
    }

    public BookCopy? GetBookByCopyNumber(string CopyNumber)
    {
        var book = bookCopyRepository.GetBookByCopyNumber(CopyNumber);
        return book;
    }
    public List<BookCategory>? GetBookByCategory(int id)
    {
        var booklist = bookCategoryRepository.GetBookByCategory(id);
        return booklist;
    }
}