using LibraryManagement.BuisnessLayerLibrary.Services;
using LibraryManagement.PresentationLayer.Frontend.Object;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class UserRole
{
    protected readonly UserService userService;
    public UserRole(UserService _userService)
    {
        userService = _userService;
    }
    public void UserRoles()
    {
        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 Get The Book Borrowed");
            Console.WriteLine("Enter 2 Get The Book Returned");
            Console.WriteLine("Enter 3 Get The OverDue Books");
            Console.WriteLine("Enter 4 For Pending Fine");
            Console.WriteLine("Enter 5 For Fine Paid/History");
            Console.WriteLine("Enter 0 To Quit");
            Console.WriteLine("------------------------------------------------");

            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 7 || typechoice < 0)
            {
                Console.WriteLine("Enter Vaild Input");
            }
            try
            {
                switch (typechoice)
                {
                    case 1:
                        {
                            GetBooksBorrowed();
                            break;
                        }
                    case 2:
                        {
                            GetBooksReturned();
                            break;
                        }
                    case 3:
                        {
                            GetBooksOverDue();
                            break;
                        }
                    case 4:
                        {
                            GetFine();
                            break;
                        }
                    case 5:
                        {
                            GetPayment();
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