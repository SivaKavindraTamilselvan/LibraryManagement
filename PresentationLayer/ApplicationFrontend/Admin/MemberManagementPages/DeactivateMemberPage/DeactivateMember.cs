using LibraryManagement.ModelLibrary.Exceptions;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class MemberManagement
{
    public void DeactivateTheMemberByMemberId(int id)
    {
        var member = adminService.DeactivateTheMemberByMemberId(id);
        if(member == null)
        {
            throw new InvalidMemberException($"Member Not Updated. Enter Valid Details");
        }
        Console.WriteLine(member);
    }
    public void DeactivateTheMemberByEmail(string email)
    {
        var member = adminService.DeactivateTheMemberByEmail(email);
        if(member == null)
        {
            throw new InvalidMemberException($"Member Not Updated. Enter Valid Details");
        }
        Console.WriteLine(member);
    }
    public void DeactivateTheMemberByPhoneNumber(string PhoneNumber)
    {
        var member = adminService.DeactivateTheMemberByPhoneNumber(PhoneNumber);
        if(member == null)
        {
            throw new InvalidMemberException($"Member Not Updated. Enter Valid Details");
        }
        Console.WriteLine(member);
    }
}