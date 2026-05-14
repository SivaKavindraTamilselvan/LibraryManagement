namespace LibraryManagement.ModelLibrary.Models;

public class Borrowing
{
    public int BorrowingId {get;set;}
    public int MemberId {get;set;}
    public Member? Member {get;set;}
    public int BookCopyId {get;set;}
    public BookCopy? BookCopy {get;set;}

    public DateTime BorrowedDate {get;set;}
    public DateTime DueDate {get;set;}
    public DateTime? ReturnDate {get;set;}
    public int BorrowingStatusId {get;set;}
    public BorrowingStatus? BorrowingStatus {get;set;}

    public DateTime createdAt {get;set;}
    public DateTime updatedAt{get;set;}
    public ICollection<Fine>? Fines {get;set;}
}