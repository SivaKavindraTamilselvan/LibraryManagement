using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Services;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class MemberManagement
{
    public void UpdateMemberManagementRoles()
    {
        while (true)
        {
            Console.WriteLine("Enter 1 To Update The Member Type Details By Email");
            Console.WriteLine("Enter 2 To Update The Member Type Details By Phone Number");
            Console.WriteLine("Enter 3 To Update The Member Type Details By Member Id");
            Console.WriteLine("Enter 0 To Quit");

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
                            int membertypeid = inputsCheck.IdInputs();
                            UpdateTheMemberTypeByEmail(email, membertypeid);
                            break;
                        }
                    case 2:
                        {
                            string phone = inputsCheck.PhoneNumberInputs();
                            int membertypeid = inputsCheck.IdInputs();
                            UpdateTheMemberTypeByPhoneNumber(phone,membertypeid);
                            break;
                        }
                    case 3:
                        {
                            int memberid = inputsCheck.IdInputs();
                            int membertypeid = inputsCheck.IdInputs();
                            UpdateTheMemberTypeByMemberId(memberid,membertypeid);
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