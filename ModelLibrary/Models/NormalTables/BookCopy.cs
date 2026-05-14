namespace LibraryManagement.ModelLibrary.Models;

public class BookCopy
{
    public int BookCopyId {get;set;}
    public int BookISBNId {get;set;}
    public string CopyNumber {get;set;} = string.Empty;
    public int BookStatusId {get;set;}
    public BookStatus? BookStatus {get;set;}
}