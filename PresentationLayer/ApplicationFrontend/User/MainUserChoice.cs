using LibraryManagement.PresentationLayer.Frontend.Object;

namespace LibraryManagement.PresentationLayer.Frontend;

public class UserRole
{
    protected readonly MemberManagement memberManagement;
    protected readonly BookManagement bookManagement;
    protected readonly BorrowingManagement borrowingManagement;
    protected readonly ReturnManagement returnManagement;
    protected readonly FineManagement fineManagement;
    protected readonly ReportManagement reportManagement;
    public UserRole(MangmentManager mangmentManager)
    {
        memberManagement = mangmentManager.memberManagement;
        bookManagement = mangmentManager.bookManagement;
        borrowingManagement = mangmentManager.borrowingManagement;
        returnManagement = mangmentManager.returnManagement;
        fineManagement = mangmentManager.fineManagement;
        reportManagement = mangmentManager.reportManagement;
    }
    public void UserRoles()
    {
        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 Get The Book Borrowed");
            Console.WriteLine("Enter 2 Get The Book Returned");
            Console.WriteLine("Enter 3 Get The OverDue Books");
            Console.WriteLine("Enter 4 Get The Book Lost");
            Console.WriteLine("Enter 5 For Pending Fine");
            Console.WriteLine("Enter 6 For Fine Paid/History");
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
                            Console.WriteLine("\n\n================= Member Management =================\n\n");
                            memberManagement.MemberManagementRoles();
                            Console.WriteLine("\n\n======================================================\n\n");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\n\n================== Book Management ==================\n\n");
                            bookManagement.BookManagementRoles();
                            Console.WriteLine("\n\n======================================================\n\n");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\n\n============= Borrowing Book Management =============\n\n");
                            borrowingManagement.BorrowingManagementRoles();
                            Console.WriteLine("\n\n======================================================\n\n");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("\n\n============== Return Book Management ==============\n\n");
                            returnManagement.ReturnManagementRoles();
                            Console.WriteLine("\n\n=====================================================\n\n");

                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("\n\n================== Fine Management ==================\n\n");
                            fineManagement.FineManagementRoles();
                            Console.WriteLine("\n\n======================================================\n\n");
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("\n\n================= Report Management =================\n\n");
                            reportManagement.ReturnManagementRoles();
                            Console.WriteLine("\n\n======================================================\n\n");
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