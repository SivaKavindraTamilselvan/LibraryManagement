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
                            string email = inputsCheck.EmailInputs();
                            DeactivateTheMemberByEmail(email);
                            break;
                        }
                    case 2:
                        {
                            string phone = inputsCheck.PhoneNumberInputs();
                            DeactivateTheMemberByPhoneNumber(phone);
                            break;
                        }
                    case 3:
                        {
                            int memberid = inputsCheck.IdInputs();
                            DeactivateTheMemberByMemberId(memberid);
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