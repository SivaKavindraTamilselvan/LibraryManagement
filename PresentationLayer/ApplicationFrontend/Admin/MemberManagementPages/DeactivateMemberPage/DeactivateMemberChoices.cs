using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Services;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class MemberManagement
{
    public void DeactivateMemberManagementRoles()
    {
        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 To Deactivate The Member By Email");
            Console.WriteLine("Enter 2 To Deactivate The Member By Phone Number");
            Console.WriteLine("Enter 3 To Deactivate The Member By Member Id");
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
                            Console.WriteLine("\n\n================ Deactivate The Member By Email ================\n");
                            Console.WriteLine("Enter The Email To Deactivate The Member");
                            string email = inputsCheck.EmailInputs();
                            DeactivateTheMemberByEmail(email);
                            Console.WriteLine("\n\n==================================================================\n");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\n\n============= Deactivate The Member By Phone Number =============\n");
                            Console.WriteLine("Enter The Phone Number To Deactivate The Member");
                            string phone = inputsCheck.PhoneNumberInputs();
                            DeactivateTheMemberByPhoneNumber(phone);
                            Console.WriteLine("\n\n==================================================================\n");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\n\n============= Deactivate The Member By Member Id =============\n");
                            Console.WriteLine("Enter The Member Id To Deactivate The Member");
                            int memberid = inputsCheck.IdInputs();
                            DeactivateTheMemberByMemberId(memberid);
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