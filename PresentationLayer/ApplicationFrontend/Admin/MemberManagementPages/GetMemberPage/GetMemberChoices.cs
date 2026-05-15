using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Services;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class MemberManagement
{
    public void GetMemberManagementRoles()
    {
        while (true)
        {
            Console.WriteLine("Enter 1 To Get All Member Details");
            Console.WriteLine("Enter 2 To Get All The Member Details By Email");
            Console.WriteLine("Enter 3 To Get All The Member Details By Phone Number");
            Console.WriteLine("Enter 4 To Get All The Member Details By User Role");
            Console.WriteLine("Enter 5 To Get All The Member Details By Admin Role");
            Console.WriteLine("Enter 6 To Get All The Member Details By Member Id");
            Console.WriteLine("Enter 0 To Quit");

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
                            GetAllMembers();
                            break;
                        }
                    case 2:
                        {
                            string email = inputsCheck.EmailInputs();
                            GetMemberByEmail(email);
                            break;
                        }
                    case 3:
                        {
                            string PhoneNumber = inputsCheck.PhoneNumberInputs();
                            GetMemberByPhoneNumber(PhoneNumber);
                            break;
                        }
                    case 4:
                        {
                            GetMemberByRole(1);
                            break;
                        }
                    case 5:
                        {
                            GetMemberByRole(2);
                            break;
                        }
                    case 6:
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