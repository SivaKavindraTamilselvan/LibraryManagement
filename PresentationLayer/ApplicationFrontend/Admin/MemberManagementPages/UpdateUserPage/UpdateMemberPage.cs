using LibraryManagement.ModelLibrary.Exceptions;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class MemberManagement
{
    public void UpdateTheMemberTypeByMemberId(int id,int MemberTypeId)
    {
        var member = adminService.UpdateTheMemberTypeByMemberId(id,MemberTypeId);
        if(member == null)
        {
            throw new InvalidMemberException($"Member Not Updated. Enter Valid Details");
        }
        Console.WriteLine(member);
        
    }
    public void UpdateTheMemberTypeByEmail(string email,int MemberTypeId)
    {
        var member = adminService.UpdateTheMemberTypeByEmail(email,MemberTypeId);
        if(member == null)
        {
            throw new InvalidMemberException($"Member Not Updated. Enter Valid Details");
        }
        Console.WriteLine(member);
    }
    public void UpdateTheMemberTypeByPhoneNumber(string PhoneNumber,int MemberTypeId)
    {
        var member = adminService.UpdateTheMemberTypeByPhoneNumber(PhoneNumber,MemberTypeId);
        if(member == null)
        {
            throw new InvalidMemberException($"Member Not Updated. Enter Valid Details");
        }
        Console.WriteLine(member);
    }
}