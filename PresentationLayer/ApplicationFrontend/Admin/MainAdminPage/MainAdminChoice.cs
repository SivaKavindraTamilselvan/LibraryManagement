namespace LibraryManagement.PresentationLayer.Frontend;

public class AdminRole
{
    protected readonly MemberManagement memberManagement;
    public AdminRole(MemberManagement _memberManagement)
    {
        memberManagement = _memberManagement;
    }
    public void AdminRoles()
    {
        while (true)
        {
            //adminChoices.DisplayAdminChoices();
            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 6 || typechoice < 0)
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
                            //adminGetRole.AdminGetRoles();
                            break;
                        }
                    case 3:
                        {
                            //UpdateUser();
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