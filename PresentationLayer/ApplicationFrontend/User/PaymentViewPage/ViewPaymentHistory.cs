using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.ModelLibrary.Exceptions;
using LibraryManagement.PresentationLayer.Frontend.Object;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class UserRole
{

    public void GetPayment()
    {
        Console.WriteLine("Enter The Member Email to get the Details");
        int id = inputsCheck.IdInputs();
        var payment = userService.GetPayments(id);
        if (payment.Count == 0)
        {
            throw new InvalidBorrowingException("Borrowing not created.Ensure the inputs");
        }
        foreach (var b in payment)
        {
            Console.WriteLine(b);
        }
    }
    public void GetFine()
    {
        Console.WriteLine("Enter The Member Email to get the Details");
        int id = inputsCheck.IdInputs();
        var borrowing = userService.GetFinePending(id);
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