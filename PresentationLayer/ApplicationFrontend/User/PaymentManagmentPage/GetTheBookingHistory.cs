using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.ModelLibrary.Exceptions;
using LibraryManagement.PresentationLayer.Frontend.Object;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class UserRole
{
    InputsCheck inputsCheck = new InputsCheck();
    public void GetBooksBorrowed()
    {
        Console.WriteLine("Enter The Member Email to get the Details");
        string email = inputsCheck.EmailInputs();
        var borrowing = userService.GetBooksBorrowed(email);
        if (borrowing.Count == 0)
        {
            throw new InvalidBorrowingException("Borrowing not created.Ensure the inputs");
        }
        foreach (var b in borrowing)
        {
            Console.WriteLine(b);
        }
    }
    public void GetBooksReturned()
    {
        Console.WriteLine("Enter The Member Email to get the Details");
        string email = inputsCheck.EmailInputs();
        var borrowing = userService.GetBooksReturned(email);
        if (borrowing.Count == 0)
        {
            throw new InvalidBorrowingException("Borrowing not created.Ensure the inputs");
        }
        foreach (var b in borrowing)
        {
            Console.WriteLine(b);
        }
    }
    public void GetBooksOverDue()
    {
        Console.WriteLine("Enter The Member Email to get the Details");
        string email = inputsCheck.EmailInputs();
        var borrowing = userService.GetBooksOverDue(email);
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