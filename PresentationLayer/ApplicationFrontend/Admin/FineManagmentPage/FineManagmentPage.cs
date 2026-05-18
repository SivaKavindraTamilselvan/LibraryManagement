using LibraryManagement.ModelLibrary.Exceptions;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class FineManagement
{
    public void AddPayment()
    {
        var fine = adminService.AddPayment();
        Console.WriteLine("\n\nPayment Added Successfully\n\n ");
        Console.WriteLine(fine);
    }
   
}