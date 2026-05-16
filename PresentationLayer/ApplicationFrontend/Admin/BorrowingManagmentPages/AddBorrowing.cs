using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Services;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class BorrowingManagement
{
    public void AddBorrowing()
    {
        adminService.AddBorrowing();
    }
}