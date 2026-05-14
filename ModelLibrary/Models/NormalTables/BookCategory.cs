namespace LibraryManagement.ModelLibrary.Models;

public class BookCategory
{
    public int BookCategoryId {get;set;}
    public string BookCategoryName {get;set;} = string.Empty;
    public ICollection<Book>? Books {get;set;}
}