using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.ModelLibrary.Exceptions;
using LibraryManagement.ModelLibrary.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public partial class AdminService
{
    public Borrowing? AddReturn()
    {
        Console.WriteLine("Enter The Borrowing Id");
        int borrowId = inputsCheck.IdInputs();
        Console.WriteLine("Enter The Borrowing Status Id");
        int bookStatus = inputsCheck.IdInputs();
        int damagedLevel = 0;
        if(bookStatus == 4)
        {
            Console.WriteLine("Enter The Damaged Level");
            damagedLevel = inputsCheck.IdInputs();
        }
        bool lost = bookStatus == 3? true : false;
        //every validation are done here
        var updatedborrowing = borrowingRepository.ReturnBorrowing(borrowId,lost,damagedLevel);
        return updatedborrowing;
    }

    public List<Borrowing> PendingReturn()
    {
        return borrowingRepository.GetPendingReturn();
    }
}