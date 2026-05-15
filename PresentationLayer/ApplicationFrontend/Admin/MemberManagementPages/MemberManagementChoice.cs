using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Services;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class MemberManagement
{
    InputsCheck inputsCheck = new InputsCheck();
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
            Console.WriteLine("Enter 2 To Get Member Details By Different Category");
            Console.WriteLine("Enter 3 To Update The Member Details");

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
                            AddMember();
                            break;
                        }
                    case 2:
                        {
                            GetMemberManagementRoles();
                            break;
                        }
                    case 3:
                        {
                            UpdateMemberManagementRoles();
                            break;
                        }
                    case 4:
                        {
                            DeactivateMemberManagementRoles();
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