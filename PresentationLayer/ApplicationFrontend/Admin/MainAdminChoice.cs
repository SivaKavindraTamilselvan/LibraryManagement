using LibraryManagement.PresentationLayer.Frontend.Object;

namespace LibraryManagement.PresentationLayer.Frontend;

public class AdminRole
{
    protected readonly MemberManagement memberManagement;
    protected readonly BookManagement bookManagement;
    protected readonly BorrowingManagement borrowingManagement;
    protected readonly ReturnManagement returnManagement;
    protected readonly FineManagement fineManagement;
    protected readonly ReportManagement reportManagement;
    public AdminRole(MangmentManager mangmentManager)
    {
        memberManagement = mangmentManager.memberManagement;
        bookManagement = mangmentManager.bookManagement;
        borrowingManagement = mangmentManager.borrowingManagement;
        returnManagement = mangmentManager.returnManagement;
        fineManagement = mangmentManager.fineManagement;
        reportManagement = mangmentManager.reportManagement;
    }
    public void AdminRoles()
    {
        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 For Member Managment");
            Console.WriteLine("Enter 2 For Book Manegment");
            Console.WriteLine("Enter 3 For Borrowing Managment");
            Console.WriteLine("Enter 4 For Return Managment");
            Console.WriteLine("Enter 5 For Fine Managment");
            Console.WriteLine("Enter 6 For Report Managment");
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
                            fineManagement.ReturnManagementRoles();
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