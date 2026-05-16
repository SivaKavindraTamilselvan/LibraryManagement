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
            Console.WriteLine("Enter 5 For Report Managment");
            Console.WriteLine("Enter 7 For Fine Managment");
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
                            memberManagement.MemberManagementRoles();
                            break;
                        }
                    case 2:
                        {
                            bookManagement.BookManagementRoles();
                            break;
                        }
                    case 3:
                        {
                            borrowingManagement.BorrowingManagementRoles();
                            break;
                        }
                    case 4:
                        {
                            //adminDeleteRole.AdminDeleteRoles();
                            break;
                        }
                    case 5:
                        {
                            //adminSendNotificationRole.AdminSendNotificationRoles();
                            break;
                        }
                    case 6:
                        {
                            //adminGetNotificationRole.AdminGetNotificationRoles();
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