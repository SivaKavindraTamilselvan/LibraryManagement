using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Services;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class MemberManagement
{
    public void UpdateMemberManagementRoles()
    {
        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 To Update The Member Type Details By Email");
            Console.WriteLine("Enter 2 To Update The Member Type Details By Phone Number");
            Console.WriteLine("Enter 3 To Update The Member Type Details By Member Id");
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
                            Console.WriteLine("\n\n================ Update Member ID Details By Member ID ================\n");
                            Console.WriteLine("Enter The Email To Update The Member");
                            string email = inputsCheck.EmailInputs();
                            Console.WriteLine("Enter The Member Type ID To Update");
                            int membertypeid = inputsCheck.IdInputs();
                            UpdateTheMemberTypeByEmail(email, membertypeid);
                            Console.WriteLine("\n\n======================================================================\n");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\n\n================= Update Member ID Details By Email =================\n");
                            Console.WriteLine("Enter The Phone Number To Update The Member");
                            string phone = inputsCheck.PhoneNumberInputs();
                            Console.WriteLine("Enter The Member Type ID To Update");
                            int membertypeid = inputsCheck.IdInputs();
                            UpdateTheMemberTypeByPhoneNumber(phone, membertypeid);
                            Console.WriteLine("\n\n======================================================================\n");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\n\n================ Update Member ID Details By PhoneNumber ================\n");
                            Console.WriteLine("Enter The Member ID To Update The Member");
                            int memberid = inputsCheck.IdInputs();
                            Console.WriteLine("Enter The Member Type ID To Update");
                            int membertypeid = inputsCheck.IdInputs();
                            UpdateTheMemberTypeByMemberId(memberid, membertypeid);
                            Console.WriteLine("\n\n======================================================================\n");
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
                Console.WriteLine("\n\n======================================================================\n");
            }
        }
    }
}