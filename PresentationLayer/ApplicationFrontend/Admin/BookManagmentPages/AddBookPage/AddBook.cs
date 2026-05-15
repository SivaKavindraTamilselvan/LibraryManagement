using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Services;

using LibraryManagement.ModelLibrary.Models;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class BookManagement
{
    public void AddBook()
    {
       var book = adminService.AddBook();
       Console.WriteLine(book);
    }
}