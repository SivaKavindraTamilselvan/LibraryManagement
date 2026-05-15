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
            Console.WriteLine("Enter 2 To Get All Member Details");
            Console.WriteLine("Enter 3 To Get All The Member Details By Email");
            Console.WriteLine("Enter 4 To Get All The Member Details By Phone Number");
            Console.WriteLine("Enter 5 To Get All The Member Details By User Role");
            Console.WriteLine("Enter 6 To Get All The Member Details By Admin Role");
            Console.WriteLine("Enter 7 To Get All The Member Details By Member Id");

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
                            string email = inputsCheck.EmailInputs();
                            GetMemberByEmail(email);
                            break;
                        }
                    case 4:
                        {
                            string PhoneNumber = inputsCheck.PhoneNumberInputs();
                            GetMemberByPhoneNumber(PhoneNumber);
                            break;
                        }
                    case 5:
                        {
                            GetMemberByRole(1);
                            break;
                        }
                    case 6:
                        {
                            GetMemberByRole(2);
                            break;
                        }
                    case 7:
                        {
                            int id = inputsCheck.IdInputs();
                            GetMemberById(id);
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