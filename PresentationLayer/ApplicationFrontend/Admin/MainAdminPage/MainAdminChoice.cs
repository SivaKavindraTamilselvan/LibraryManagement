namespace LibraryManagement.PresentationLayer.Frontend;

public class AdminRole
{
    protected readonly MemberManagement memberManagement;
    protected readonly BookManagement bookManagement;
    protected readonly BorrowingManagement borrowingManagement;
    public AdminRole(MemberManagement _memberManagement, BookManagement _bookManagement,BorrowingManagement _borrowingManagement)
    {
        memberManagement = _memberManagement;
        bookManagement = _bookManagement;
        borrowingManagement = _borrowingManagement;
    }
    public void AdminRoles()
    {
        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 For Member Management");
            Console.WriteLine("Enter 2 For Book Manegement");
            Console.WriteLine("Enter 3 For Book Borrowing");
            Console.WriteLine("Enter 0 To Quit");
            Console.WriteLine("------------------------------------------------");

            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 3 || typechoice < 0)
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