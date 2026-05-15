namespace LibraryManagement.ModelLibrary.Models;

public class Book
{
    public int BookId {get;set;}
    public string BookTitle {get;set;} = string.Empty;
    public string Author {get;set;} = string.Empty;
    public int BookCategoryId {get;set;}
    public BookCategory? BookCategory {get;set;}
    public ICollection<BookISBN> BookISBNs {get;set;} = new List<BookISBN>();
    public override string ToString()
    {
        return $"BookId : {BookId}\nBookTitle : {BookTitle}\nAuthor : {Author}\nBookCategoryId : {BookCategoryId}\nBookCategoryName : {BookCategory?.BookCategoryName}";
    }
}