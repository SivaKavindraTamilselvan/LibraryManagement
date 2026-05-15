using LibraryManagement.BuisnessLayerLibrary.Services;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class MemberManagement
{
    protected readonly AdminService adminService;
    public MemberManagement(AdminService _adminService)
    {
        adminService = _adminService;
    }
    public void MemberManagementRoles()
    {
        while (true)
        {
            Console.WriteLine("Enter 1 To Add The Member");
            Console.WriteLine("Enter 2 To Get All Member Details");
            Console.WriteLine("Enter 3 To Get All The Member Details By Email");
            Console.WriteLine("Enter 4 To Get All The Member Details By Phone Number");
            Console.WriteLine("Enter 5 To Get All The Member Details By Role");

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
                            AddMember();
                            break;
                        }
                    case 2:
                        {
                            GetAllMembers();
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