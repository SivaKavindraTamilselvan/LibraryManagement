using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Services;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class ReportManagement
{
    InputsCheck inputsCheck = new InputsCheck();
    protected readonly AdminService adminService;
    public ReportManagement(AdminService _adminService)
    {
        adminService = _adminService;
    }
    public void ReturnManagementRoles()
    {
        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 To Get The Report Of The Book Borrowed");
            Console.WriteLine("Enter 2 To Get The Report Of The OverDue Book");
            Console.WriteLine("Enter 3 To Get The Report Of The Members With Pending Fine");
            Console.WriteLine("Enter 4 To Get The Report Of The Available Books");
            Console.WriteLine("Enter 5 To Get The Report Of The Member History");
            Console.WriteLine("Enter 6 To Get The Report Of The Book History");            
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
                            //AddReturn();
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
