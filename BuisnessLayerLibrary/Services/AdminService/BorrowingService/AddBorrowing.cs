using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.ModelLibrary.Exceptions;
using LibraryManagement.ModelLibrary.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public partial class AdminService
{
    public Borrowing? AddBorrowing()
    {
        Console.WriteLine("\n\n================ Enter The Details To Borrow The Book =================\n\n");
        Console.WriteLine("Enter The Member Id");
        int memberId = inputsCheck.IdInputs();
        Console.WriteLine("Enter The Book Title To Borrow");
        string title = Console.ReadLine() ?? "";
        var book = GetBookIdByTitle(title);
        if(book == null)
        {
            throw new InvalidBookException("Book Not Found");
        }
        var borrowing = borrowingRepository.CreateBorrowing(memberId,book.BookId);
        if(borrowing == null)
        {
            return null;
        }
        return borrowing;
    }
}