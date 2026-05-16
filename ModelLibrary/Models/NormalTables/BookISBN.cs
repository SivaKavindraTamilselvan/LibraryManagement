namespace LibraryManagement.ModelLibrary.Models;

public class BookISBN
{
    public int BookISBNId { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int Edition { get; set; }
    public int BookId { get; set; }
    public Book? Book { get; set; }
    public ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();

    public override string ToString()
    {
        return $"BookISBNId : {BookISBNId}\nBookISBN : {ISBN}\nPublished Year : {PublishedYear}\nEdition: {Edition}";
    }
    public string GetAllBookISBN()
    {
        string bookISBN = ToString() + "\n\n--------- Copy Book Details ---------\n\n" + (BookCopies.Any() ? string.Join("\n\n--------- Copy Book Details ---------\n\n", BookCopies.Select(bc => bc.GetAllBookCopyByStatus())) : "No Book Copies Added For This Book Till Now");
        return bookISBN;
    }
}