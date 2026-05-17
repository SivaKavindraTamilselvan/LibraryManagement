using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Services;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class BorrowingManagement
{
    public void AddBorrowing()
    {
        var borrowing = adminService.AddBorrowing();
        Console.WriteLine("\n\n----------------- Borrowimg Details -----------------\n\n");
        Console.WriteLine(borrowing);
    }
}