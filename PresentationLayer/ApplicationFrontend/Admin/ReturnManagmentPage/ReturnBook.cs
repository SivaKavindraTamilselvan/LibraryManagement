using LibraryManagement.ModelLibrary.Exceptions;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class ReturnManagement
{
    public void AddReturn()
    {
        var borrowing = adminService.AddReturn();
        if(borrowing == null)
        {
            throw new InvalidBorrowingException("Error In The Returning The Book");
        }
        Console.WriteLine("Book Retuned Successfully");
        Console.WriteLine(borrowing);
    }

    public void GetReturn()
    {
        var borrowing = adminService.PendingReturn();
        if(borrowing.Count == 0)
        {
            throw new InvalidBorrowingException("No Pending Return The Book");
        }
        foreach(var b in borrowing)
        {
            Console.WriteLine(b);
        }
    }
}