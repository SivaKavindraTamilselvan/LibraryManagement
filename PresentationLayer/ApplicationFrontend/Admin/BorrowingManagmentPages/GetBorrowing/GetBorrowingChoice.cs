using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Services;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class BorrowingManagement
{
    public void GetBorrowingManagementRoles()
    {
        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 To Get Borrowing Details By Borrowing Id");
            Console.WriteLine("Enter 2 To Get Borrowing Details By Member Id");
            Console.WriteLine("Enter 3 To Get Borrowing Details By Member Email");
            Console.WriteLine("Enter 4 To Get Borrowing Details By Borrowing Status");
            Console.WriteLine("Enter 5 To Get Borrowing Details By Borrowing Date");
            Console.WriteLine("Enter 6 To Get Borrowing Details By Return Date");
            Console.WriteLine("Enter 7 To Get Borrowing Details By Due Date");
            Console.WriteLine("Enter 8 To Get Borrowing Details That Have The Due Date Tomorrow");
            Console.WriteLine("Enter 9 To Get Borrowing Details By Book Title");
            Console.WriteLine("Enter 10 To Get Borrowing Details By Book Copy Id");
            Console.WriteLine("Enter 0 To Quit");
            Console.WriteLine("------------------------------------------------");

            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 4 || typechoice < 0)
            {
                Console.WriteLine("Enter Vaild Input");
            }
            try
            {
                switch (typechoice)
                {
                    case 1:
                        {
                            AddBorrowing();
                            break;
                        }
                    case 2:
                        {
                            //GetMemberManagementRoles();
                            break;
                        }
                    case 3:
                        {
                            //UpdateMemberManagementRoles();
                            break;
                        }
                    case 4:
                        {
                            //DeactivateMemberManagementRoles();
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
