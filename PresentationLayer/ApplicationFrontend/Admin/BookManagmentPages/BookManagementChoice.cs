using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Services;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class BookManagement
{
    InputsCheck inputsCheck = new InputsCheck();
    protected readonly AdminService adminService;
    public BookManagement(AdminService _adminService)
    {
        adminService = _adminService;
    }
    public void BookManagementRoles()
    {
        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 To Add The Book");
            Console.WriteLine("Enter 2 To Get Book Details By Different Category");
            Console.WriteLine("Enter 3 To Update The Book Details");
            Console.WriteLine("Enter 0 To Quit");
            Console.WriteLine("------------------------------------------------");

            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 5 || typechoice < 0)
            {
                Console.WriteLine("Enter Vaild Input");
            }
            try
            {
                switch (typechoice)
                {
                    case 1:
                        {
                            AddBookManagementRoles();
                            break;
                        }
                    case 2:
                        {
                            GetBookManagementRoles();
                            break;
                        }
                    case 3:
                        {
                            //AddBookCopy();
                            break;
                        }
                    case 0:
                        {
                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}