using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Services;

using LibraryManagement.ModelLibrary.Models;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class BookManagement
{
    public void AddBook()
    {
        Console.WriteLine("\n\n============= Add The Book Basic Details =============\n");
        var book = adminService.AddBook();
        Console.WriteLine(book);
        Console.WriteLine("\n\n=======================================================\n");
    }

    public void AddBookISBN()
    {
        Console.WriteLine("\n\n============= Add The Book ISBN Details =============\n");
        var book = adminService.AddBookISBN();
        Console.WriteLine(book);
        Console.WriteLine("\n\n=======================================================\n");
    }

    public void AddBookCopy()
    {
        Console.WriteLine("\n\n============= Add The Book Copy Details =============\n");
        var book = adminService.AddBookCopy();
        Console.WriteLine(book);
        Console.WriteLine("\n\n=======================================================\n");
    }
}