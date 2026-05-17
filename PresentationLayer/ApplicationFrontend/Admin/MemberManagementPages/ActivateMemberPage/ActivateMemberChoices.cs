using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Services;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class MemberManagement
{
    public void ActivateMemberManagementRoles()
    {
        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 To activate The Member By Email");
            Console.WriteLine("Enter 2 To activate The Member By Phone Number");
            Console.WriteLine("Enter 3 To activate The Member By Member Id");
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
                            Console.WriteLine("\n\n================ Activate The Member By Email ================\n");
                            string email = inputsCheck.EmailInputs();
                            ActivateTheMemberByEmail(email);
                            Console.WriteLine("\n\n==================================================================\n");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\n\n============= Activate The Member By Phone Number =============\n");
                            string phone = inputsCheck.PhoneNumberInputs();
                            ActivateTheMemberByPhoneNumber(phone);
                            Console.WriteLine("\n\n==================================================================\n");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\n\n============= Activate The Member By Member Id =============\n");
                            int memberid = inputsCheck.IdInputs();
                            ActivateTheMemberByMemberId(memberid);
                            Console.WriteLine("\n\n==================================================================\n");
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
                Console.WriteLine("\n\n==================================================================\n");
            }
        }
    }
}