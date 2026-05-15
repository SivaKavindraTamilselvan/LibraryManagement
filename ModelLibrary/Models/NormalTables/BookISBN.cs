namespace LibraryManagement.ModelLibrary.Models;

public class BookISBN
{
    public int BookISBNId {get;set;}
    public string ISBN {get;set;} = string.Empty;
    public int PublishedYear {get;set;}
    public int Edition {get;set;}
    public int BookId {get;set;}
    public Book? Book {get;set;}
    public ICollection<BookCopy>? BookCopies {get;set;}

    public override string ToString()
    {
        return $"BookISBNId : {BookISBNId}\nPublished Year : {PublishedYear}\nEdition: {Edition}\nBookId : {BookId}";
    }
    
}