namespace LibraryManagement.PresentationLayer.Frontend;

public partial class ReturnManagement
{
    public void AddReturn()
    {
        var borrowing = adminService.AddReturn();
        Console.WriteLine(borrowing);
    }
}