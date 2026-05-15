namespace LibraryManagement.ModelLibrary.Models;

public class BorrowingStatus
{
    public int BorrowingStatusId {get;set;}
    public string BorrowingStatusName {get;set;} = string.Empty;
    public ICollection<Borrowing> Borrowings {get;set;} = new List<Borrowing>();
}