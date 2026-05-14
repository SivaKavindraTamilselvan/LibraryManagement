namespace LibraryManagement.ModelLibrary.Models;

public class Book
{
    public int BookId {get;set;}
    public string BookTitle {get;set;} = string.Empty;
    public string Authot {get;set;} = string.Empty;
    public int BookingCategoryId {get;set;}
    public BookCategory? BookCategory {get;set;}
    public ICollection<BookISBN>? BookISBNs {get;set;}
}