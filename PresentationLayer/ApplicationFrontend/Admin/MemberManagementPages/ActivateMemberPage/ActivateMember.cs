using LibraryManagement.ModelLibrary.Exceptions;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class MemberManagement
{
    public void ActivateTheMemberByMemberId(int id)
    {
        var member = adminService.ActivateTheMemberByMemberId(id);
        if(member == null)
        {
            throw new InvalidMemberException($"Member Not Updated. Enter Valid Details");
        }
        Console.WriteLine(member);
    }
    public void ActivateTheMemberByEmail(string email)
    {
        var member = adminService.ActivateTheMemberByEmail(email);
        if(member == null)
        {
            throw new InvalidMemberException($"Member Not Updated. Enter Valid Details");
        }
        Console.WriteLine(member);
    }
    public void ActivateTheMemberByPhoneNumber(string PhoneNumber)
    {
        var member = adminService.ActivateTheMemberByPhoneNumber(PhoneNumber);
        if(member == null)
        {
            throw new InvalidMemberException($"Member Not Updated. Enter Valid Details");
        }
        Console.WriteLine(member);
    }
}