using LibraryManagement.ModelLibrary.Exceptions;
using LibraryManagement.ModelLibrary.Models;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class BorrowingManagement
{
    public void GetBorrowingById()
    {
        Console.WriteLine("Enter The Borrowing Id to get the Details");
        int id = inputsCheck.IdInputs();
        var borrowing = adminService.GetBorrowingById(id);
        if (borrowing == null)
        {
            throw new InvalidBorrowingException("Borrowing not created.Ensure the inputs");
        }
        Console.WriteLine(borrowing);
    }
    public void GetBorrowingByMemberId()
    {
        Console.WriteLine("Enter The Member Id to get the Details");
        int id = inputsCheck.IdInputs();
        var borrowing = adminService.GetBorrowingByMemberId(id);
        if (borrowing.Count == 0)
        {
            throw new InvalidBorrowingException("Borrowing not created.Ensure the inputs");
        }
        foreach (var b in borrowing)
        {
            Console.WriteLine(b);
        }
    }
    public void GetBorrowingByMemberEmail()
    {
        Console.WriteLine("Enter The Member Email to get the Details");
        string email = inputsCheck.EmailInputs();
        var borrowing = adminService.GetBorrowingByMemberEmail(email);
        if (borrowing.Count == 0)
        {
            throw new InvalidBorrowingException("Borrowing not created.Ensure the inputs");
        }
        foreach (var b in borrowing)
        {
            Console.WriteLine(b);
        }
    }
    public void GetBorrowingByStatus()
    {
        Console.WriteLine("Enter The Status Id to get the Details");
        int id = inputsCheck.IdInputs();
        var borrowing = adminService.GetBorrowingByBorrowingStatus(id);
        if (borrowing.Count == 0)
        {
            throw new InvalidBorrowingException("Borrowing not created.Ensure the inputs");
        }
        foreach (var b in borrowing)
        {
            Console.WriteLine(b);
        }
    }
    public void GetBorrowingByBorrowingBorrowdate()
    {
        Console.WriteLine("Enter The Borrow Date to get the Details");
        DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
        var borrowing = adminService.GetBorrowingByBorrowingDate(dateTime);
        if (borrowing.Count == 0)
        {
            throw new InvalidBorrowingException("Borrowing not created.Ensure the inputs");
        }
        foreach (var b in borrowing)
        {
            Console.WriteLine(b);
        }
    }
    public void GetBorrowingByBorrowingDuedate()
    {
        Console.WriteLine("Enter The Due Date to get the Details");
        DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
        var borrowing = adminService.GetBorrowingByDueDate(dateTime);
        if (borrowing.Count == 0)
        {
            throw new InvalidBorrowingException("Borrowing not created.Ensure the inputs");
        }
        foreach (var b in borrowing)
        {
            Console.WriteLine(b);
        }
    }
    public void GetBorrowingByBorrowingReturnDate()
    {
        Console.WriteLine("Enter The Due Date to get the Details");
        DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
        var borrowing = adminService.GetBorrowingByReturnDate(dateTime);
        if (borrowing.Count == 0)
        {
            throw new InvalidBorrowingException("Borrowing not created.Ensure the inputs");
        }
        foreach (var b in borrowing)
        {
            Console.WriteLine(b);
        }
    }
    public void GetBorrowingTmrw()
    {

        var borrowing = adminService.GetBorrowingTmrw();
        if (borrowing.Count == 0)
        {
            throw new InvalidBorrowingException("Borrowing not created.Ensure the inputs");
        }
        foreach (var b in borrowing)
        {
            Console.WriteLine(b);
        }
    }
    public void GetBorrowingByBookTitle()
    {
        Console.WriteLine("Enter The Book Title to get the Details");
        string title = Console.ReadLine() ?? "";
        var borrowing = adminService.GetBorrowingByBookTitle(title);
        if (borrowing.Count == 0)
        {
            throw new InvalidBorrowingException("Borrowing not created.Ensure the inputs");
        }
        foreach (var b in borrowing)
        {
            Console.WriteLine(b);
        }
    }

    public void GetBorrowingByBookCopyId()
    {
        Console.WriteLine("Enter The BookCopy Id to get the Details");
        int id = inputsCheck.IdInputs();
        var borrowing = adminService.GetBorrowingByBookCopy(id);
        if (borrowing.Count == 0)
        {
            throw new InvalidBorrowingException("Borrowing not created.Ensure the inputs");
        }
        foreach (var b in borrowing)
        {
            Console.WriteLine(b);
        }
    }
}